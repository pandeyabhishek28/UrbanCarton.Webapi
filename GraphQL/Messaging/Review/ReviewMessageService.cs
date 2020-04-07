using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.GraphQL.Messaging.Review
{
    public class ReviewMessageService
    {
        private readonly ReplaySubject<Message> _messageStream = new ReplaySubject<Message>();

        public IObservable<Message> GetMessages()
        {
            return _messageStream.AsObservable();
        }

        public Message AddReviewAddedMessage(ProductReview productReview)
        {
            var message = new Message
            {
                ProductId = productReview.Id,
                Title = productReview.Title,
                Comments = productReview.Review
            };

            _messageStream.OnNext(message);
            return message;
        }

        public void Dispose()
        {
            _messageStream.Dispose();
        }
    }
}
