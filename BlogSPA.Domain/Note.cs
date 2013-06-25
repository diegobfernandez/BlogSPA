using System;
using System.Collections.Generic;

namespace BlogSPA.Domain
{
    public class Note
    {
        public Note()
        {
        }

        public Note(string title, NoteType type)
        {
            Title = title;
            Messages = new List<string>();
            Type = type;
        }

        public Note(string title, IEnumerable<string> messages, NoteType type)
        {
            Title = title;
            Messages = messages;
            Type = type;
        }

        public Note(string title, string message, NoteType type)
        {
            Title = title;
            Messages = new List<string> { message };
            Type = type;
        }

        public enum NoteType
        {
            Success,
            Warning,
            Error
        }

        public string Title { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public NoteType Type { get; set; }
    }
}
