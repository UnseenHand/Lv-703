using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Homework12
{
    [Serializable]
    [DataContract]
    public struct Point
    {
        private int x;
        private int y;
        [XmlAttribute]
        [DataMember]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        [XmlAttribute]
        [DataMember]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void PointOutput()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", X, Y);
        }
    }
}
