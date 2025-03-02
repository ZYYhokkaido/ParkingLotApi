﻿using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException()
        {
        }

        public InvalidCapacityException(string? message) : base(message)
        {
        }

        public InvalidCapacityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
