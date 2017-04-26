using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BackendBot.Models;

namespace BackendBot.Dialogs
{


    [LuisModel("99e3d255-88ea-4c78-8213-520b70e29fdf", "279f4f31fa6346219ce61e04a5cb34d6")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        public string EntityProductName { get; private set; }
        private IList<string> titleOptions = new List<string> {
                    "Bullguard Internet Security",
                    "Bullguard Premium Protection",
                    "BullGuard Premium Services",
                    "Bullguard Mobile Security",
                    "Bullguard Antivirus"
        };

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("FindProducts")]
        public async Task Search(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var message = await activity;
            await context.PostAsync($"Finding products: '{message.Text}'...");

            var productsQuery = new ProductQuery();
            var productsFormDialog = new FormDialog<ProductQuery>(productsQuery, this.BuildProductsForm, FormOptions.PromptInStart, result.Entities);

            context.Call(productsFormDialog, this.ResumeAfterProductsFormDialog);
        }

        [LuisIntent("Refund")]
        public async Task Reviews(IDialogContext context, LuisResult result)
        {
            EntityRecommendation productEntityRecommendation;

            if (result.TryFindEntity(EntityProductName, out productEntityRecommendation))
            {
                await context.PostAsync($"Looking for '{productEntityRecommendation.Entity}' products...");

                var resultMessage = context.MakeMessage();
                resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                resultMessage.Attachments = new List<Attachment>();

                for (int i = 0; i < 5; i++)
                {
                    var random = new Random(i);
                    ThumbnailCard thumbnailCard = new ThumbnailCard()
                    {
                        Title = this.titleOptions[random.Next(0, this.titleOptions.Count - 1)],
                        Text = "Description for...",
                        Images = new List<CardImage>()
                        {
                            new CardImage() { Url = "https://www.bullguard.com/shop/Content/Img/Site2016/product_box_is.png" }
                        },
                    };

                    resultMessage.Attachments.Add(thumbnailCard.ToAttachment());
                }

                await context.PostAsync(resultMessage);
            }

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Try asking me things like 'I want a refund', 'I want to renew my subscription' or 'show me products'");

            context.Wait(this.MessageReceived);
        }

        private IForm<ProductQuery> BuildProductsForm()
        {
            OnCompletionAsyncDelegate<ProductQuery> processProductsSearch = async (context, state) =>
            {
                var message = "Searching for products";
                if (!string.IsNullOrEmpty(state.ClientIdentifier))
                {
                    message += $" in {state.ClientIdentifier}...";
                }
                else if (!string.IsNullOrEmpty(state.ProductId))
                {
                    message += $" in {state.ProductId.ToUpperInvariant()}...";
                }

                await context.PostAsync(message);
            };

            return new FormBuilder<ProductQuery>()
                .Field(nameof(ProductQuery.ClientIdentifier), (state) => string.IsNullOrEmpty(state.ProductId))
                .Field(nameof(ProductQuery.ProductId), (state) => string.IsNullOrEmpty(state.ClientIdentifier))
                .OnCompletion(processProductsSearch)
                .Build();
        }

        private async Task ResumeAfterProductsFormDialog(IDialogContext context, IAwaitable<ProductQuery> result)
        {
            try
            {
                var searchQuery = await result;

                var products = await this.GetProductsAsync(searchQuery);

                await context.PostAsync($"I found {products.Count()} products:");

                var resultMessage = context.MakeMessage();
                resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                resultMessage.Attachments = new List<Attachment>();

                foreach (var product in products)
                {
                    HeroCard heroCard = new HeroCard()
                    {
                        Title = product.Name,
                        Subtitle = $"{product.Description}",
                        Images = new List<CardImage>()
                        {
                            new CardImage() { Url = product.Image }
                        },
                        Buttons = new List<CardAction>()
                        {
                            new CardAction()
                            {
                                Title = "More details",
                                Type = ActionTypes.OpenUrl,
                                Value = $"https://www.bullguard.com/shop/"
                            }
                        }
                    };

                    resultMessage.Attachments.Add(heroCard.ToAttachment());
                }

                await context.PostAsync(resultMessage);
            }
            catch (FormCanceledException ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }

        private async Task<IEnumerable<Product>> GetProductsAsync(ProductQuery searchQuery)
        {
            var products = new List<Product>();

            //Retrieve these from a mock product repository
            for (int i = 1; i <= 5; i++)
            {
                var random = new Random(i);
                Product newProduct = new Product()
                {
                    Name = $"",
                    Description = $"",
                    Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_av.png"
                };

                products.Add(newProduct);
            }

            return products;
        }
    }
}
