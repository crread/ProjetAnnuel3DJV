using System;

namespace Entity
{
    public class ScoreEntity
    {
        public DateTime score_date;
        public string name;

        public ScoreEntity(DateTime score_date, string name)
        {
            this.name = name;
            this.score_date = score_date;
        }
    }
}
