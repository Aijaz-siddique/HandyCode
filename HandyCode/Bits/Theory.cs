
        /*
         
         Bit Manipulation

        Set = 1, Unset = 0

        We want i-th bit to be set
	        => We have to left shift by i position
	
	        e.g. 1 << 0 ---> 1
		         1 << 1 ---> 10
		         1 << 2 ---> 100
		 
		         **************
		         *   1 << i   *
		         **************
         
         

        "2 ke power wale number ke just pehle wale number me saara bit 1 hota hai"



        =========================================================================================
        =========================================================================================

        (a & (1 << i) != 0) ----------> Check if i-th bit is set or not
        (a | (1 << i))      -----------> Set the i-th bit
        (a & (~(1 << i) ))  -----------> Unset the i-th bit
        (a ^ (1 << i))      -----------> Toggle the bit ON/OFF
        (a & 1) == 1 ?      -----------> Number is Odd
        (a & 1) != 1 ?      -----------> Number is Even
        (A | ' ')           -----------> Convert Upper case to Lower case letter
        (a & '_')           -----------> Convert Lower case to Upper case letter

        (a & (~ ((1<<(i+1)) - 1) ) -----> Clear all LSB bits till a i-th position
        (a & ((1 << (i+1)) - 1))  -----> Clear all MSB bits till a i-th position

        (n & (n-1)) == 0         -----------> Check power of 2; This equation means n is Power of 2

        =========================================================================================
        =========================================================================================




        Swap using XOR
        a = 4
        b = 6
                a = a^b
                b = a^b
                a = a^b;


        XOR table
        1 0        1
        0 1        1
        0 0        0
        1 1        0



         */
