/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events.External;
using Read.TextMessageRecievedFeatures;

namespace Read.SmsRecievedFeatures
{
    public class TextMessageReceivedEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IReceivedTextMessages _receivedTextMessages;

        public TextMessageReceivedEventProcessor(IReceivedTextMessages receivedTextMessages)
        {
            _receivedTextMessages = receivedTextMessages;
        }

        //TODO: Add test that sends TextMessageReceived events and verifies that the correct events are emitted
        public void Process(TextMessageReceived @event)
        {            
            var message = _receivedTextMessages.GetById(@event.Id) ?? new ReceivedTextMessage(@event.Id);
            message.Keyword = @event.Keyword;
            message.Message = @event.Message;
            message.OriginNumber = @event.OriginNumber;
            message.ReceivedAtGatewayNumber = @event.ReceivedAtGatewayNumber;
            message.Sent = @event.Sent;
            message.Location = new Location(@event.Latitude, @event.Longitude);
            _receivedTextMessages.Save(message);            
        }
    }
}
