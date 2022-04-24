namespace efef
{
    
    class NodeDeq
    {
        
        public NodeDeq next = null;
        public NodeDeq prev = null;
        public int num;
        public NodeDeq(int inf, NodeDeq n = null, NodeDeq p = null) { 
            num = inf;
            next = n;
            prev = p;
        }
    }
    public class Deque
    {
        NodeDeq head;
        NodeDeq tail;
        private int Len;
        public int Length{
            get => Len;
        }
        public int Front{
            get => head.num;
        }
         public int Last{
            get => tail.num;
        }     
        public void AddLast(int num){
            // if list is empty
            if (head == null)
            {
                head = new NodeDeq(num);
                tail = head;
                Len++;
                return;
            } else 
            // if head == tail (1 element in list)
            if (tail.prev == null)
            {
                tail = new NodeDeq(num, tail, head);
                head.next = tail;
                Len++;
                return;
                
            } else {
                tail.next = new NodeDeq(num, null, tail);
                tail = tail.next;
                Len++;
            }
        }
        public void AddFront(int num){
            // if list is empty
            if (head == null)
            {
                head = new NodeDeq(num);
                tail = head;
                Len++;
                return;
            } else 
            // if head == tail (1 element in list)
            if (head.prev == null)
            {
                //NodeDeq current = head;
                head.prev = new NodeDeq(num, head, null);;
                head = head.prev;
                Len++;
                return;
                
            } else {
                head.prev = new NodeDeq(num, head, null);
                head = head.prev;
                Len++;
            }
        }
        public static void Print(Deque a){
            var current = a.head;
            System.Console.Write("[");
            while (current != null)
            {
                if (current == a.tail)
                {
                    System.Console.Write($"{current.num}");
                    break;
                }
                System.Console.Write($"{current.num}, ");
                current = current.next;
            }
            System.Console.Write("]\n");
        }
        public void RemoveLast(){
            if (Len == 0)
            { 
                throw new NullReferenceException("Queue is empty!");
            } 
            if (Len == 1)
            {
                head = null;
                tail = null;
                Len--;
                return;
            }
            tail = tail.prev;
            tail.next = null;
            Len--;
            return;
            
        }
       public void RemoveFront(){
            if (Len == 0)
            { 
                throw new NullReferenceException("Queue is empty!");
            } 
            if (Len == 1)
            {
                head = null;
                tail = null;
                Len--;
                return;
            }
            head = head.next;
            head.prev = null;
            Len--;
            return;
            
    }
}
}