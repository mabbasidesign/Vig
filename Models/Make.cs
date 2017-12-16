using System.Collections.Generic;

namespace Vig.Models
{
    public class Make
    {
        public int id  { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}