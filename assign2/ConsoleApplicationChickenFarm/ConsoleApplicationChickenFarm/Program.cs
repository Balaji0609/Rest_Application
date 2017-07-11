using System;
using System.Threading;

namespace ConsoleApplicationChickenFarm
{
    //delegates used for the puporse of threading and call back event handling.
    
    // delegate used for the price cut event.
    public delegate void priceCutEvent(double pr);
    // delegate used for manging the buffer cells.
    public delegate void bufferDelegate();
    // delegate used for the purpose of notifying the user about the process.
    public delegate void orderNotification(int orID, Boolean flag, double charges);



    /// <summary>
    /// Handler class for the notification delegate and event handling object creation.
    /// </summary>
    class NotificationClass
    {
        public static event orderNotification orEvent; // Event for ordernotification delegate.
        public void orderComp(int orID, Boolean flag, double charges)
        {
            if(orEvent != null)
            {
                orEvent(orID, flag, charges);
            }
        }
    }

    /// <summary>
    /// Class that does the order processing for the chicken farm.
    /// </summary>
    class OrderProcessing
    {
        public static double tax = 1; // tax levied on the chickens.
        public static double ship = 1; // the shipping charges for each chicken.

        private OrderClass or;

        // constructor for instantiating the orderprocessing class.
        public OrderProcessing(OrderClass or)
        {
            this.or = or;
        }

        // processing each and every order by verifying the card details of  the retailer.
        public void orderprocess()
        {
            int cardNo = or.getCardNo();
            NotificationClass N = new NotificationClass();
            if(cardNo > 5000 && cardNo < 7000 )
            {
                int total = or.getAmount();
                double Price = or.getPrice();
                double Tcost = (total * Price) + (total * ship) + (total * tax);
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Order details : - ");
                Console.WriteLine("Rtailer ID - {0}", or.getSenderId());
                Console.WriteLine("Order ID - {0}", or.getOrderNo());
                Console.WriteLine("No of Chickens Ordered - {0}", or.getAmount());
                Console.WriteLine("Price of each chicken - ${0}", Math.Round(or.getPrice(),2));
                Console.WriteLine("Tax per chicken - ${0}", tax);
                Console.WriteLine("Shipping per chicken - ${0}", ship);
                Console.WriteLine("!!!! Total cost of Chicken !!!! - ${0}", Math.Round(Tcost,2));
                Console.WriteLine("------------------------------------------------------");
                N.orderComp(or.getOrderNo(), true, Tcost);
            }
            else
            {
                //Console.WriteLine(" values {0} {1} {2}");
                N.orderComp(or.getOrderNo(), false, 0);
            }

        }
    }



    /// <summary>
    /// class that handles the buffer side of the system which manages the buffer cell.
    /// </summary>
    public class BufferClass
    {
        int Size;
        private BufferCell[] cells;
        private Semaphore sync;

        /// <summary>
        ///  class that defines a buffer cell.
        /// </summary>
        class BufferCell
        {
            public bool flag;
            public string data;
            public BufferCell()
            {
                flag = false;
            }
        }

        static readonly object lockobj = new object();
        static BufferClass bufferclass = null;
        public static event bufferDelegate bufferevent;

        // constructor which is synchronized due to multi threads.
        static BufferClass()
        {
            lock(lockobj)
            {
                bufferclass = new BufferClass();
            }
        }

        // event that returns the buffer object.
        public static BufferClass getCell()
        {
            lock(lockobj)
            {
                return bufferclass;
            }
        }

        // method that is used for putting the retailers request into the cell so that they can be processed by the farm.
        public void putInBufferCell(string or)
        {
            sync.WaitOne(); // used for synchronization.
            Random rnd = new Random();
            int i = rnd.Next(0, Size - 1);
            while(true)
            {
                i = (i + 1) % Size;
                if(Monitor.TryEnter(cells[i]))
                {
                    if(cells[i].flag == false)
                    {
                        cells[i].data = or;
                        cells[i].flag = true;
                        Monitor.Exit(cells[i]); // locking mechanism.
                        bufferevent();
                        break;
                    }
                    Monitor.Exit(cells[i]);
                }
            }
        }

        // This method is used for the purpose of processing the buffercell by the farm.
        public string processBufferCell()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, Size - 1);
            string temp = "";
            while(true)
            {
                i = (i + 1) % Size;
                if(Monitor.TryEnter(cells[i]))
                {
                    if(cells[i].flag)
                    {
                        temp = cells[i].data;
                        cells[i].flag = false;
                        Monitor.Exit(cells[i]);
                        break;
                    }
                    Monitor.Exit(cells[i]);
                }
            }
            sync.Release();
            return temp;
        }

        // This method is used for initializing the buffer based on the given buffer size whwich is 3 here. 
        public static void initBuffer(int s)
        {
            lock(lockobj)
            {
                if(bufferclass != null)
                {
                    bufferclass.Size = s;
                    bufferclass.sync = new Semaphore(s, s);
                    bufferclass.cells = new BufferCell[s];
                    int i = 0;
                    while(i < s)
                    {
                        bufferclass.cells[i] = new BufferCell();
                        i++;
                    }
                }
            }
        }

    }

    /// <summary>
    /// Used for calculating a pricing for the chickens on a defined algorithm.
    /// </summary>
    class PricingModel
    {
        double Price;
        public int counter = 0;
        public void setPrice(double Price)
        {
            this.Price = Price;
        }
        // This method is the implementation of the algorithm that is used for the purpose of cost calculation.
        public double generatePrice()
        {
            Random num = new Random();
            double val = 0.20;
 
            double tempPrice = this.Price;
            if(counter % 5 == 0)
            {
                val = val - 0.10;
                tempPrice = Math.Abs(tempPrice - (tempPrice * val));
            }
            else
            {
                val = val - 0.05;
                tempPrice = Math.Abs(tempPrice + (tempPrice * val));
            }
            return tempPrice;
        }
    }

    /// <summary>
    /// Decoder is a class orEvent a method in a class: The Decoder will convert the string back into the OrderObject.
    /// </summary>
    class Decoder
    {
        public static OrderClass decode(string orderStr)
        {
            OrderClass order = new OrderClass();
            string[] members = orderStr.Split('*');
            order.setSenderId(int.Parse(members[0]));
            order.setCardNo(int.Parse(members[1]));
            order.setAmount(int.Parse(members[2]));
            order.setOrderNo(int.Parse(members[3]));
            order.setPrice(double.Parse(members[4]));
            return order;
        }
    }

    /// <summary>
    /// Encoder is a class or Event a method in a class: The Encoder class will convert an OrderObject into a string.
    /// </summary>
    class Encoder
    {
        // This method encodes the object into a string with * inbetween them.
        public static string encode(OrderClass order)
        {
            string encodedStr = "";
            encodedStr += order.getSenderId().ToString() + "*" + order.getCardNo().ToString() + "*" + order.getAmount().ToString() + "*"+ order.getOrderNo().ToString() + "*" + order.getPrice().ToString();
            return encodedStr;
        }
    }

    /// <summary>
    /// Class that defines the object for this system.
    /// </summary>
    public class OrderClass
    {

        Boolean flag;
        double charges;
        private int senderId;
        private int cardNo;
        private int amount;
        private int orderNo;
        DateTime orderTime;
        double Price;
        string timeDiff;
        string orStatus;

        // constructor for the class
        public OrderClass()
        {
            this.orStatus = "created";
            this.flag = false;
            this.timeDiff = "0";
            this.charges = 0;
        }

        // getters and setters for the class variables.
        public string getOrStatus()
        {
            return this.orStatus;
        }
        public void setOrStatus(string orstatus)
        {
            this.orStatus = orstatus;
        }
        public string getTimeDiff()
        {
            return this.timeDiff;
        }
        public void setTimeDiff(string timeDiff)
        {
            this.timeDiff = timeDiff;
        }
        public Boolean getFlag()
        {
            return this.flag;
        }
        public void setFlag(Boolean flag)
        {
            this.flag = flag;
        }
        public void setCharges(Double charges)
        {
            this.charges = charges;
        }
        public Double getCharges()
        {
            return this.charges;
        }
        public void setPrice(Double price)
        {
            this.Price = price;
        }
        public Double getPrice()
        {
            return Price;
        }
        public void setOrderNo(int orderNo)
        {
            this.orderNo = orderNo;
        }
        public int getOrderNo()
        {
            return this.orderNo;
        }
        public void setOrderTime(DateTime orderTime)
        {
            this.orderTime = orderTime;
        }
        public DateTime getOrderTime()
        {
            return this.orderTime;
        }
        public void setSenderId(int senderId)
        {
            this.senderId = senderId;
        }
        public int getSenderId()
        {
            return this.senderId;
        }
        public void setCardNo(int cardNo)
        {
            this.cardNo = cardNo;
        }
        public int getCardNo()
        {
            return this.cardNo;
        }
        public void setAmount(int amount)
        {
            this.amount = amount;
        }
        public int getAmount()
        {
            return this.amount;
        }
    }

    /// <summary>
    /// class for creating unique orderid so that the thread wont ovelap.
    /// </summary>
    public class SynchronizedClass
    {
        public static int orderCounter = 0;
        public int synchronizedCounter()
        {
            lock (this)
            {
                return orderCounter++;
            }
        }
    }

    /// <summary>
    /// Chicken Farm application.This class handles the queries from the retailers.
    /// </summary>
    public class ChickenFarm
    {
        static Random rng; // to generate random numbers.
        public static int Orders, PriceCutval, PriceCut2;
        public static DateTime start, end;
        public static double PriceFarm;
        public static event priceCutEvent priceCut;//Link event to delegate.
        
        //private static Int32 chickenPrice = 10;

        // constructor for the the chickenfarm class.
        public ChickenFarm(double Price, int cut)
        {
            PriceFarm = Price;
            PriceCutval = 0;
            PriceCut2 = cut;
            Orders = 0;
            rng = new Random();
        }

        public void addorders(int curr)
        {
            lock (this)
            {
                Orders += curr;
            }
        }

        // getters and setters for the class variables.
        public int getorders()
        {
            lock (this)
            {
                return Orders;
            }
        }

        public void setPriceFarm(double Price)
        {
            lock (this)
            {
                PriceFarm = Price;
            }
        }

        public double getPriceFarm()
        {
            lock (this)
            {
                return PriceFarm;
            }
        }


        // This method process the ordering from the retailer.
        public void ordering()
        {
            string content;
            BufferClass buff = BufferClass.getCell();
            content = buff.processBufferCell();
            OrderClass or = Decoder.decode(content);
            OrderProcessing obj = new OrderProcessing(or);
            addorders(or.getAmount());
            Thread PThread = new Thread(new ThreadStart(obj.orderprocess));
            PThread.Start();
        }


        // Handles the change price.
        public static void changePrice(double price)
        {
            if (price < PriceFarm) // a price cut.
            {
                PriceFarm = price;
                if (priceCut != null) // there is at least a subscriber.
                {
                    Console.WriteLine("Price cut event called with new price - ${0} ", price);
                    priceCut(price); // emit event to subscrciber.
                    PriceCutval++;
                    if (PriceCut2 == PriceCutval)
                    {
                        end = DateTime.Now;
                        Console.WriteLine("Farmer Thread Duration - {0}", (start - end).TotalSeconds.ToString());
                        Thread.CurrentThread.Abort();
                    }
                }
            }
            PriceFarm = price;
        }


        // This method identifies the cost change and notifies it to the user.
        public void farmerFunc()
        {
            double tempP;
            PricingModel M = new PricingModel();
            Boolean flag = false;

            while (PriceCutval != PriceCut2)
            {
                Thread.Sleep(1000);
                // Take the orderComp from the queue of the orders;
                //Decide the price based on the orders.  
                Console.WriteLine("Farmer Side Thread");
                if (flag == false)
                {
                    start = DateTime.Now;
                    flag = true;
                }

                M.setPrice(getPriceFarm());
                M.counter++;
                tempP = M.generatePrice();
                Console.WriteLine("There is a change in price");
                Console.WriteLine("New Price is {0}", tempP);
                ChickenFarm.changePrice(tempP);
            }
        }
    }

    /// <summary>
    /// Retailer class for handling retailers.
    /// </summary>
    public class Retailer
    {
        // parameters of a retailer.
        private int retailerId;
        private double chickenPrice;
        private int chickenNo;
        private int cardNo;
        private int odCounter = 0;
        OrderClass[] or = new OrderClass[1000];

        //class constructor for object creation.
        public Retailer(int retailerId, Double chickenPrice, int chickenNo, int cardNo)
        {
            this.retailerId = retailerId;
            this.chickenPrice = chickenPrice;
            this.chickenNo = chickenNo;
            this.cardNo = cardNo;
        }

        // setters and getters for the in class parameters.
        public int getOdCounter()
        {
            return odCounter;
        }
        public int getCardNo()
        {
            return cardNo;
        }
        public int getChickenNo()
        {
            return chickenNo;
        }
        public int getRetailerId()
        {
            return retailerId;
        }
        public double getChickenPrice()
        {
            return chickenPrice;
        }
        public void setOdCounter(int odCounter)
        {
            this.odCounter = odCounter;
        }
        public void setCardNo(int cardNo)
        {
            this.cardNo = cardNo;
        }
        public void setChickenNo(int chickenNo)
        {
            this.chickenNo = chickenNo;
        }
        public void setRetailerId(int retailerId)
        {
            this.retailerId = retailerId;
        }
        public void setChickenPrice(double chickenPrice)
        {
            this.chickenPrice = chickenPrice;
        }

        // This method notifies the user about the details of the order being processed.This method also calculates the time i.e the time stamp of time taken to process the request.
        public void orderNotify(int odNo, Boolean flg, double charg)
        {
            int orNo;
            int i = 0;
            while (i < odCounter)
            {
                orNo = or[i].getOrderNo();
                if (odNo == orNo)
                {
                    or[i].setCharges(charg);
                    or[i].setFlag(flg);
                    DateTime curr = DateTime.Now;
                    string time = (curr - or[i].getOrderTime()).TotalSeconds.ToString();
                    or[i].setTimeDiff(time);
                    if (or[i].getFlag() == false)
                    {
                        Console.WriteLine("Retailer's {0} order is Rejected whose order id is = {1} and process time taken = {2} Sec", retailerId, orNo, time);
                        or[i].setOrStatus("Rejected");
                    }
                    else
                    {
                        Console.WriteLine("Retailer's {0} order is completed the order id is = {1} and process time taken = {2} Sec", retailerId, orNo, time);
                        or[i].setOrStatus("Completed");
                    }
                    break;
                }
                i += 1;
            }
        }

        //This method creates the order obj which is then processed to process the order.
        public void orderObj()
        {
            or[odCounter] = new OrderClass();
            SynchronizedClass ob = new SynchronizedClass();
            or[odCounter].setOrderNo(ob.synchronizedCounter());
            or[odCounter].setOrderTime(DateTime.Now);
            or[odCounter].setSenderId(this.retailerId);
            or[odCounter].setAmount(this.chickenNo);
            or[odCounter].setCardNo(this.cardNo);
            or[odCounter].setPrice(this.chickenPrice);
            odCounter += 1;


        }

        public void retailerFunc() // for starting thread.
        {
            BufferClass buff = BufferClass.getCell();
            string orCell;
            while(true)
            {
                Thread.Sleep(1000);
                orderObj();
                orCell = Encoder.encode(or[odCounter - 1]);
                buff.putInBufferCell(orCell);
                Console.WriteLine("Retailer {0} has been placed into the cell with price ${1}", this.retailerId, Math.Round(this.chickenPrice));
            }
            //ChickenFarm chicken = new ChickenFarm();
            //for (Int32 i = 0; i < 10; i++)
            //{
                //   Thread.Sleep(1000);
                //  Int32 p = chicken.getPrice();
                // Console.WriteLine("Store {0} has everyday low price : ${1} each", Thread.CurrentThread.Name, p);
            // }
           
        }

        //Based on the percent of price drop calculating the amount of chicken needed by the retailer.
        public int nextOrder(double P)
        {
            double Pchange = this.chickenPrice - P;
            double PercntChange = (Pchange * 100 )/ this.chickenPrice;
            int num = this.chickenNo;
            if(PercntChange <= 30 && PercntChange > 0 )
            {
                num = num + 1;
            }
            else if(PercntChange > 30 && PercntChange <= 60)
            {
                num = num + 2;
            }
            else if(PercntChange > 60)
            {
                num = num + 3;
            }
            return num;
        }

        public void chickenOnSale(double p) // event handler orderComp chickens from chicken farm - send orderComp into queue.
        {
            Console.WriteLine("Retailer {0} gets price cut event new price from chicken farm is ${1}", retailerId, Math.Round(p, 3));
            this.chickenNo = nextOrder(p);
            this.chickenPrice = p;
            //Console.WriteLine("Sending orderComp into queue");
            //Console.WriteLine("Store {0} has everyday low price : ${1} each", Thread.CurrentThread.Name, p);
        }


    }

    /// <summary>
    /// Class which hold the main function which calls all the threads and runs them.
    /// </summary>
    public class myApplication
    {
        static void Main(string[] args)
        {
            int RetailersNo;
            double startPrice;
            int startChickenNo;
            int BufferCellSize;
            int noOfPricecut;
            Random r = new Random();

            Console.WriteLine("********** Welcome to the chicken farm system***************");

            RetailersNo = 5;
            startPrice = 10;
            startChickenNo = 5;
            BufferCellSize = 3;
            noOfPricecut = 5;

            int[] card = new int[5];

            int i = 0; 
            while(i < RetailersNo)
            {
                card[i] = r.Next(5000, 7000);
                i += 1 ;
            }

            NotificationClass N = new NotificationClass();


            ChickenFarm chicken = new ChickenFarm(startPrice, noOfPricecut);

            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));

            
            Retailer[] chickenstore = new Retailer[5];

            BufferClass.initBuffer(BufferCellSize);
            BufferClass.bufferevent += new bufferDelegate(chicken.ordering);
            //

            Thread[] retailers = new Thread[5];
            farmer.Start(); // start one farmer thread.
            int j = 0;
            while(j < 5)
            {
                // start N retailer threads
                chickenstore[j] = new Retailer(j, startPrice, startChickenNo, card[j]);
                ChickenFarm.priceCut += new priceCutEvent(chickenstore[j].chickenOnSale);
                NotificationClass.orEvent += new orderNotification(chickenstore[j].orderNotify);
                retailers[j] = new Thread(new ThreadStart(chickenstore[j].retailerFunc));
                retailers[j].Name = (j + 1).ToString();
                retailers[j].Start();
                j += 1;
            }

            while(farmer.IsAlive)
            {
                Thread.Sleep(1000);
            }
            int k = 0;
            while(k < 5)
            {
                retailers[k].Abort();
                k++;
            }

            Console.WriteLine("*************End of execution***********");
            Console.WriteLine("PRESS ENTER TO EXIT!!!");
            Console.ReadLine();

        }
    }

}
