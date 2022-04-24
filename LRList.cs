namespace efef
{
    class NodeLR{
        public NodeLR next = null;
        public NodeLR prev = null;
        public int num;
        public NodeLR(int inf, NodeLR n = null, NodeLR p = null) { 
            num = inf;
            next = n;
            prev = p;
        }
        
    }
    public class LRList
    {
        NodeLR head;
        NodeLR tail;
        private int Len;
        public int Length{
            get => Len;
        }
        public void Remove(int index){
        if (index >= Len || index < 0)
        {
            throw new NullReferenceException("Bro, this index is out of range:(");
        }
        if (Len == 0)
        {
            throw new NullReferenceException("Bro, list is empty");
        }
        if (Len == 1)
            {
                head = null;
                tail = null;
                Len--;
                return;
            }
        var current = head;
        // remove 1st element
        if (index == 0)
        {
            head = head.next;
            Len--;
            return;
        }
        // remove last element
        if (index == Len - 1)
        {
            tail = current;
            tail.next = null;
            Len--;
            return;
        }
        // remove random element
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            current.prev.next = current.next;
            current.next.prev = current.prev;
            Len--;

        }
        public void Add(int num){
            // if list is empty
            if (head == null)
            {
                head = new NodeLR(num);
                tail = head;
                Len++;
                return;
            } else 
            // if head == tail (1 element in list)
            if (tail.prev == null)
            {
                tail = new NodeLR(num, tail, head);
                head.next = tail;
                Len++;
                return;
                
            } else {
                tail.next = new NodeLR(num, null, tail);
                tail = tail.next;
                Len++;
            }
        }
        public void Add(int num, int pos){
            if (pos >= this.Len || pos < 0)
        {
            throw new NullReferenceException("Bro, this index is out of range:(");
        }
        // add front
        if (pos == 0)
        {
            NodeLR current = head;
            head.prev = new NodeLR(num, current, null);;
            head = head.prev;
            Len++;
            return;
        }
        // add last
        if (pos == Len - 1)
        {
            Add(num);
            return;
        }
        // if index closer to the head / to the tail
        if (pos < Len / 2 + Len % 2)
        {
            NodeLR current = head;
        
        for (int i = 0; i < pos; i++)
        {
            current = current.next;
        }
        current.prev.next = new NodeLR(num, current.prev.next, current.prev);
        current.prev = new NodeLR(num, current.next.prev, current.prev);
            Len++;
        } else {
            NodeLR current = tail;
            for (int i = Len - 1; i > pos; i--)
        {
            current = current.prev;
        }
            current.prev.next = new NodeLR(num, current.prev.next, current.prev);
            current.prev = new NodeLR(num, current.next.prev, current.prev);
            Len++;
        }
        }
        public int GetIndex(int i){
             if (Len == 0)
        {
            throw new NullReferenceException("Bro, list is empty");
        }
            NodeLR front = head, back = tail;
            int index = 0;
            while(true){
                if (front.num == i)
                {
                    return index;
                }
                if (back.num == i)
                {
                    return Len - 1 - index;
                }
                if (front.next == null || back.prev == null)
                {
                     throw new NullReferenceException("Bro, there is no such value:(");
                }
                index++;
                front = front.next;
                back = back.prev;
            }
            
        }
        public int GetValue(int i){
             if (Len == 0)
        {
            throw new NullReferenceException("Bro, list is empty");
        }
            NodeLR front = head, back = tail;
            int index = 0;
            if (i <= Len && i < 0)
            {
                throw new NullReferenceException("Bro, this index is out of range:(");
            }
                
            if (i > Len/2+1)
            {
                while(index != i){
                    index++;
                    tail = tail.prev;
                }
                return back.num;
            } else {
                 while(index != i){
                    index++;
                    front = front.next;
                }
                return front.num;
            }
            
            
            
            
        }
        public static void Print(LRList a){
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
        
    }
}