namespace BrandMonitor.Models
{
    public class ExpertAnalysisResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Paragraph
    {
        public List<int> sentences { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Sentence
    {
        public List<int> phrases { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Phras
    {
        public List<int> tokens { get; set; }
        public string type { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Dependency
    {
        public int id { get; set; }
        public int head { get; set; }
        public string label { get; set; }
    }

    public class Token
    {
        public int syncon { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string type { get; set; }
        public string lemma { get; set; }
        public string pos { get; set; }
        public Dependency dependency { get; set; }
        public string morphology { get; set; }
        public int paragraph { get; set; }
        public int sentence { get; set; }
        public int phrase { get; set; }
    }

    public class MainSentence
    {
        public string value { get; set; }
        public decimal score { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Position
    {
        public int start { get; set; }
        public int end { get; set; }
    }

    public class MainLemma
    {
        public string value { get; set; }
        public decimal score { get; set; }
        public List<Position> positions { get; set; }
    }

    public class MainSyncon
    {
        public int syncon { get; set; }
        public string lemma { get; set; }
        public decimal score { get; set; }
        public List<Position> positions { get; set; }
    }

    public class Topic
    {
        public string label { get; set; }
        public int id { get; set; }
        public decimal score { get; set; }
        public bool winner { get; set; }
    }

    public class Property
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Knowledge
    {
        public int syncon { get; set; }
        public string label { get; set; }
        public List<Property> properties { get; set; }
    }

    public class Item2
    {
        public string lemma { get; set; }
        public int syncon { get; set; }
        public decimal sentiment { get; set; }
        //public List<Item> items { get; set; }
    }

    public class Sentiment
    {
        public decimal overall { get; set; }
        public decimal negativity { get; set; }
        public decimal positivity { get; set; }
        //public List<Item> items { get; set; }
    }

    public class Verb
    {
        public string text { get; set; }
        public string lemma { get; set; }
        public int syncon { get; set; }
        public int phrase { get; set; }
        public string type { get; set; }
        public int relevance { get; set; }
    }

    public class Related
    {
        public string relation { get; set; }
        public string text { get; set; }
        public string lemma { get; set; }
        public int syncon { get; set; }
        public string type { get; set; }
        public int phrase { get; set; }
        public int relevance { get; set; }
    }

    public class Relation
    {
        public Verb verb { get; set; }
        public List<Related> related { get; set; }
    }

    public class Data
    {
        public string content { get; set; }
        public string language { get; set; }
        public string version { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Sentence> sentences { get; set; }
        public List<Phras> phrases { get; set; }
        public List<Token> tokens { get; set; }
        public List<MainSentence> mainSentences { get; set; }
        public List<object> mainPhrases { get; set; }
        public List<MainLemma> mainLemmas { get; set; }
        public List<MainSyncon> mainSyncons { get; set; }
        public List<Topic> topics { get; set; }
        public List<object> entities { get; set; }
        public List<Knowledge> knowledge { get; set; }
        public Sentiment sentiment { get; set; }
        public List<Relation> relations { get; set; }
    }
}
