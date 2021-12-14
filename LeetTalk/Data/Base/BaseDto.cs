using System;

namespace LeetTalk.Data.Base
{
    public class BaseDto
    {
        protected BaseDto()
        {
            Guid = Guid.NewGuid();
        }
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}