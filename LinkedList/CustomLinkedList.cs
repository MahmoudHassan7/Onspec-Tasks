using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class Node
    {
        public int value;
        public Node next;
        
        public Node(int value)
        {
            this.value = value;
            next = null;
        }
    }
    class CustomLinkedList
    {
        public Node head;

        public int size;

        public CustomLinkedList()
        {
            size = 0;
        }
        public void AddItem(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                Node newItem = new Node(value);
                temp.next = newItem;

            }
            size++;
        }

        public void DeleteItemFromEnd(int indexFromEnd)
        {
            int index = size - indexFromEnd;

            Node prevtemp = null;
            Node temp = head;
            int i = 0;
            
            while (i < index)
            {
                prevtemp = temp;
                temp = temp.next;
                i++;
            }

            if (prevtemp == null)
            {
                head = head.next;
            }
            else
            {
                prevtemp.next = temp.next;
            }

            size--;
        }
    }
}
