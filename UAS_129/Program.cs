using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_129
{
    class Node
    {
        public int nomor_buku;
        public string judul_buku;
        public string nama_pengarang;
        public int tahun_terbit;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nb;
            string jb;
            string np;
            int tt;
            Console.WriteLine("\nMasukkan Nomor buku");
            nb = Convert.ToInt32(System.Console.ReadLine());
            Console.WriteLine("\nMasukkan judul buku");
            jb = Console.ReadLine();
            Console.WriteLine("\nMasukkan Nama Pengarang");
            np = Console.ReadLine();
            Console.WriteLine("\nMasukkan Tahun Terbit");
            tt = Convert.ToInt32(System.Console.ReadLine());
            Node newNode = new Node();
            newNode.nomor_buku = nb;
            newNode.judul_buku = jb;
            newNode.nama_pengarang = np;
            newNode.tahun_terbit = tt;  
            
            if (START == null ||  tt <= START.tahun_terbit)
            {
                if ((START != null) && (tt <= START.tahun_terbit))
                {
                    Console.WriteLine("\nDuplicat nomor tidak di ijinkan");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && tt >= current.tahun_terbit;
                previous = current, current = current.next)
            {
                if (tt == current.tahun_terbit)
                {
                    Console.WriteLine("\nDuplicat nomor tidak di ijinkan");
                    return;
                }
            }
            newNode.next = current;
            previous.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.tahun_terbit; previous = current,
                current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }

            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.tahun_terbit + " " + currentNode.judul_buku + " " + currentNode.nama_pengarang + " " + currentNode.nomor_buku + "\n");
            }
        }

        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nRecord in the Descending order of" + "roll number are:\n");
            Node currentNode;
            for (currentNode = START; currentNode != null; currentNode = currentNode.next)
            { }
            while (currentNode != null)
            {
                Console.Write(currentNode.tahun_terbit + "" + currentNode.judul_buku + "" + currentNode.nama_pengarang + "" + currentNode.nomor_buku + "\n");
                currentNode = currentNode.prev;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan List");
                    Console.WriteLine("2. Menghapus list");
                    Console.WriteLine("3. Melihat Semua record di ascending order  Tahun Terbit");
                    Console.WriteLine("4. Melihat Semua records in  descending order Tahun Terbit");
                    Console.WriteLine("5. Pencarian List ");
                    Console.WriteLine("6. Keluar\n");
                    Console.WriteLine("Masukkan Pilihan (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.WriteLine("\nMasukkan Tahun Terbit" + " Berhasil di Hapus: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Tidak Ditemukan");
                                else
                                    Console.WriteLine("Menyimpan Tahun Terbit" + rollNo + "Hapus \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nMasukkan TahunTerbit: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nTahun Terbit :" + curr.tahun_terbit);
                                    Console.WriteLine("\nJudul Buku : " + curr.judul_buku);
                                    Console.WriteLine("\nNama Pengarang :" + curr.nama_pengarang);
                                    Console.WriteLine("\nNomor Buku :" + curr.nomor_buku);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nOpsi Tidak Valid");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }   
}






