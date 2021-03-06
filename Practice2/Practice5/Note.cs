using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5
{

    enum State
    {
        Completed, 
        Active, 
        Inactive
    }

    class Note
    {
        public string Name { get; set; }
        public State State { get; set; }
        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    public class NotesStore
    {
        //private Note[] notes;
        private List<Note> notes;
        private Dictionary<string, Note> notesDict = new Dictionary<string, Note>();
        public int Count 
        { 
            get
            {
                return notes.Count;
            }
        }

        public int Count2 => notes.Count;

        public NotesStore()
        {

        }

        public void AddNote(string name, string state)
        {
            if (Enum.IsDefined(typeof(State), state))
            {

            }
        }

        public void DeleteNote(string name)
        {

        }
    }
}
