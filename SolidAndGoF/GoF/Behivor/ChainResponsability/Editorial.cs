using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.ChainResponsability
{
    public class Editorial
    {
        public class Document
        {
            public string Name { get; }
            public string Content { get; }

            public Document(string name, string content)
            {
                Content = content;
                Name = name;
            }
        }

        public abstract class Handler
        {
            protected Handler successor;

            public void SetSuccessor(Handler successor)
            {
                this.successor = successor;
            }

            public abstract string HandleRequest(Document document);

        }
        public class EditorLJr : Handler
        {
            public override string HandleRequest(Document document)
            {
                if (document.Content.Length < 10)
                    return $"Document {document.Name} was reviwed by Editor Jr";
                return successor.HandleRequest(document);
            }

        }
        public class EditorLSsr : Handler
        {
            public override string HandleRequest(Document document)
            {
                if (document.Content.Length >= 10 && document.Content.Length < 15)
                    return $"Document {document.Name}  was reviwed by Editor SSR";
                return successor.HandleRequest(document);
            }
        }
        public class EditorLSr : Handler
        {
            public override string HandleRequest(Document document)
            {
                if (document.Content.Length >= 15 && document.Content.Length < 20)
                    return $"Document {document.Name}  was reviwed by Editor SR";
                return successor.HandleRequest(document);
            }
        }
        public class Executive : Handler
        {
            public override string HandleRequest(Document document) => $"Document {document.Name}  was reviwed by Executive";
        }
    }
}
