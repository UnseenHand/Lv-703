using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Homework12
{
    [Serializable]
    [DataContract]
    public class Triangle
    {
        private Point a;
        private Point b;
        private Point c;
        [XmlElement(ElementName = "Point_A")]
        [DataMember(Name = "Point_A")]
        public Point A
        {
            get { return a; }
            set { a = value; }
        }
        [XmlElement(ElementName = "Point_B")]
        [DataMember(Name = "Point_B")]
        public Point B
        {
            get { return b; }
            set { b = value; }
        }
        [XmlElement(ElementName = "Point_C")]
        [DataMember(Name = "Point_C")]
        public Point C
        {
            get { return c; }
            set { c = value; }
        }
        public Triangle()
        {

        }
        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double DistanceBetweenTwoPoints(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
        public double Perimeter()
        {
            if ((A.X == B.X && B.X == C.X) || (A.Y == B.Y && B.Y == C.Y))
            {
                Console.WriteLine("Your triangle does not exist with inputed points!!!");
                return 0;
            }
            else
            {
                return DistanceBetweenTwoPoints(A, C) + DistanceBetweenTwoPoints(B, C) + DistanceBetweenTwoPoints(A, C);
            }
        }
        public double Area()
        {
            double halfOfPerimeter = (double)Perimeter() / 2;
            return Math.Sqrt(halfOfPerimeter * (halfOfPerimeter - DistanceBetweenTwoPoints(A, B)) *
                (halfOfPerimeter - DistanceBetweenTwoPoints(B, C)) * (halfOfPerimeter - DistanceBetweenTwoPoints(A, C)));
        }
        public void TriangleOutput()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return string.Format($"Triangle values:\nVertex A: ({A.X}, {A.Y})\nVertex B: ({B.X}, {B.Y})\nVertex C: ({C.X}, {C.Y})");
        }
    }
}
