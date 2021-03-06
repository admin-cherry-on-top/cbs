/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read.TextMessageRecievedFeatures
{
    public class ReceivedTextMessage
    {
        public ReceivedTextMessage()
        {
            Location = Location.NotSet;
        }

        public ReceivedTextMessage(Guid id) : this()
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public DateTimeOffset Sent { get; set; }
        public string OriginNumber { get; set; }
        public string Message { get; set; }
        public string Keyword { get; set; }
        public string ReceivedAtGatewayNumber { get; set; }
        public Location Location { get; set; }
    }
}
