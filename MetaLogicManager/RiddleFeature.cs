using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;


namespace MetaLogicManager
{
    public class RiddleFeature : IEnumerable<RiddleSet>
    {
        private readonly UserCachingProxy r_User;
        private List<RiddleSet> m_RiddlesCollection;

        public RiddleFeature(UserCachingProxy i_User)
        {
            r_User = i_User;
            initRiddlesCollection();
        }

        public ISortStrategy SortStratgey { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<RiddleSet> GetEnumerator()
        {
            foreach (RiddleSet currRiddleSet in m_RiddlesCollection)
            {
                yield return currRiddleSet;
            }
        }

        public void SortRiddles()
        {
            int i, j;
            RiddleSet temp;

            for (i = 0; i < m_RiddlesCollection.Count - 1; i++)
            {
                for (j = 0; j < m_RiddlesCollection.Count - i - 1; j++)
                {
                    if (SortStratgey.NeedSwap(m_RiddlesCollection[j].Riddle, m_RiddlesCollection[j + 1].Riddle))
                    {
                        temp = m_RiddlesCollection[j];
                        m_RiddlesCollection[j] = m_RiddlesCollection[j + 1];
                        m_RiddlesCollection[j + 1] = temp;
                    }
                }
            }
        }

        private void initRiddlesCollection()
        {
            string albumsNames = "";

            m_RiddlesCollection = new List<RiddleSet>()
            {
                {new RiddleSet("1. How many albums do you have?", r_User.Albums.Count.ToString())},
                {new RiddleSet("5. How many pages do you like?",  r_User.LikedPages.Count.ToString())},
                {new RiddleSet("4. What is the name of the last page you liked?", r_User.LikedPages.Count != 0 ? r_User.LikedPages[0].Name : "You didnt like any page yet :(")},
                {new RiddleSet("3. In how many groups are you participating?", r_User.Groups.Count.ToString())},
                {new RiddleSet("2. What are the names of your albums?", "")}
            };
            foreach (var album in r_User.Albums)
            {
                albumsNames += album.Name;
                albumsNames += ",";
            }

            m_RiddlesCollection[m_RiddlesCollection.Count - 1].Answer = albumsNames;
        }
    }
}



