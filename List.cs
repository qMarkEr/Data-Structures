namespace efef
{
    class Node
        {
            public Node next;
            public int num;
            public Node(int inf, Node n = null){
                num = inf;
                next = n;
            }
        }
    class List
    {  
    Node head = null;
    private int len;
    public int GetIndex(int num){
        int i = 0;
        Node current = head;
        while(current.num != num){
            i++;
            current = current.next;
            if (i >= len)
            {
                throw new NullReferenceException("Bro, there is no such value:("); 
            }
        }
        
        return i;
    }
    public void Remove(int index){
        if (index < 0 || index >= len)
        {
            throw new NullReferenceException("Bro, this index is out of range:("); 
        }
        Node current = head;
        if (index == 0)
        {
            head = head.next;
            len--;
            return;
        }
         if (index == len - 1)
        {
            current.next = null;
            len--;
            return;
        }
        for (int i = 0; i < index - 1; i++)
        {
            current = current.next;
        }
       
        current.next = current.next.next;
        len--;
        
    }
    public int Length{
        get => len;
    }
    public void Add(int info){
        if (head == null)
        {
            head = new Node(info);
            len++;
            return;
        } else {
            Node current = head;
            while(current.next != null){
                current = current.next;
            }
            current.next = new Node(info);
            len++;
        }
        
    }
    public static void Print(List a){
        Node cur = a.head;
        System.Console.Write("[");
        while(cur.next != null){
            System.Console.Write($"{cur.num}, ");
            cur = cur.next;

        }
        System.Console.Write($"{cur.num}]\n");
        
    }
    public void Add(int num, int index){
        if (index >= this.len || index < 0)
        {
            throw new NullReferenceException("Bro, this index is out of range:(");
        }
        Node current = this.head;
        if (index == 0)
        {
            this.head = new Node(num, current);
            len++;
            return;
        }

        
        for (int i = 0; i < index-1; i++)
        {
            current = current.next;
        }

        current.next = new Node(num, current.next);
        len++;

    }
    public int GetValue(int pos){
        if (pos >= this.len || pos < 0)
        {
            throw new NullReferenceException("Bro, this index is out of range:(");
        }
        Node current = head;
        for (int i = 0; i < pos; i++)
        {
            current = current.next;
        }
        
        
        return current.num;
        

    }
    }
}