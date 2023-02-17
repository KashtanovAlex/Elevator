using System;
using System.Collections.Concurrent;

namespace Elevator.Model
{
	public static class MessageModel
	{
        public static BlockingCollection<string> MessageDictionary = new BlockingCollection<string>();
    }
}

