using System;

namespace Laba1
{
    // Расположения узла относительно родителя
    public enum Side
    {
        Left,
        Right
    }
    
    public class TreeNode<T> where T : IComparable
    {
        public TreeNode(T data)
        {
            Data = data;
        }
        
        // Данные узла
        public T Data { get; set; }
        
        // Левая ветка
        public TreeNode<T> LeftNode { get; set; }

        // Правая ветка
        public TreeNode<T> RightNode { get; set; }

        // Родитель
        public TreeNode<T> ParentNode { get; set; }
        
        // Расположение узла относительно его родителя
        public Side? NodeSide =>
            ParentNode == null
                ? (Side?)null
                : ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;
        
        // Преобразование экземпляра класса в строку
        public override string ToString() => Data.ToString();
    }
}