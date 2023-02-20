using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;

namespace SQLTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Assign
            List<Customer> expectedCustomers = new List<Customer> {
new Customer(1,"Luís","Gonçalves","Brazil","12227-000","+55 (12) 3923-5555","luisg@embraer.com.br"),
new Customer(2,"Leonie","Köhler","Germany","70174","+49 0711 2842222","leonekohler@surfeu.de"),
new Customer(3,"François","Tremblay","Canada","H2G 1A7","+1 (514) 721-4711","ftremblay@gmail.com"),
new Customer(4,"Bjorn","Hansen","Norway","0171","+47 22 44 22 22","bjorn.hansen@yahoo.no"),
new Customer(5,"Frantisek","Wichterlová","Czech Republic","14700","+420 2 4172 5555","frantisekw@jetbrains.com"),
new Customer(6,"Helena","Holy","Czech Republic","14300","+420 2 4177 0449","hholy@gmail.com"),
new Customer(7,"Astrid","Gruber","Austria","1010","+43 01 5134505","astrid.gruber@apple.at"),
new Customer(8,"Daan","Peeters","Belgium","1000","+32 02 219 03 03","daan_peeters@apple.be"),
new Customer(9,"Kara","Nielsen","Denmark","1720","+453 3331 9991","kara.nielsen@jubii.dk"),
new Customer(10,"Eduardo","Martins","Brazil","01007-010","+55 (11) 3033-5446","eduardo@woodstock.com.br"),
new Customer(11,"Alexandre","Rocha","Brazil","01310-200","+55 (11) 3055-3278","alero@uol.com.br"),
new Customer(12,"Roberto","Almeida","Brazil","20040-020","+55 (21) 2271-7000","roberto.almeida@riotur.gov.br"),
new Customer(13,"Fernanda","Ramos","Brazil","71020-677","+55 (61) 3363-5547","fernadaramos4@uol.com.br"),
new Customer(14,"Mark","Philips","Canada","T6G 2C7","+1 (780) 434-4554","mphilips12@shaw.ca"),
new Customer(15,"Jennifer","Peterson","Canada","V6C 1G8","+1 (604) 688-2255","jenniferp@rogers.ca"),
new Customer(16,"Frank","Harris","USA","94043-1351","+1 (650) 253-0000","fharris@google.com"),
new Customer(17,"Jack","Smith","USA","98052-8300","+1 (425) 882-8080","jacksmith@microsoft.com"),
new Customer(18,"Michelle","Brooks","USA","10012-2612","+1 (212) 221-3546","michelleb@aol.com"),
new Customer(19,"Tim","Goyer","USA","95014","+1 (408) 996-1010","tgoyer@apple.com"),
new Customer(20,"Dan","Miller","USA","94040-111","+1 (650) 644-3358","dmiller@comcast.com"),
new Customer(21,"Kathy","Chase","USA","89503","+1 (775) 223-7665","kachase@hotmail.com"),
new Customer(22,"Heather","Leacock","USA","32801","+1 (407) 999-7788","hleacock@gmail.com"),
new Customer(23,"John","Gordon","USA","2113","+1 (617) 522-1333","johngordon22@yahoo.com"),
new Customer(24,"Frank","Ralston","USA","60611","+1 (312) 332-3232","fralston@gmail.com"),
new Customer(25,"Victor","Stevens","USA","53703","+1 (608) 257-0597","vstevens@yahoo.com"),
new Customer(26,"Richard","Cunningham","USA","76110","+1 (817) 924-7272","ricunningham@hotmail.com"),
new Customer(27,"Patrick","Gray","USA","85719","+1 (520) 622-4200","patrick.gray@aol.com"),
new Customer(28,"Julia","Barnett","USA","84102","+1 (801) 531-7272","jubarnett@gmail.com"),
new Customer(29,"Robert","Brown","Canada","M6J 1V1","+1 (416) 363-8888","robbrown@shaw.ca"),
new Customer(30,"Edward","Francis","Canada","K2P 1L7","+1 (613) 234-3322","edfrancis@yachoo.ca"),
new Customer(31,"Martha","Silk","Canada","B3S 1C5","+1 (902) 450-0450","marthasilk@gmail.com"),
new Customer(32,"Aaron","Mitchell","Canada","R3L 2B9","+1 (204) 452-6452","aaronmitchell@yahoo.ca"),
new Customer(33,"Ellie","Sullivan","Canada","X1A 1N6","+1 (867) 920-2233","ellie.sullivan@shaw.ca"),
new Customer(34,"Joao","Fernandes","Portugal","NULL","+351 (213) 466-111","jfernandes@yahoo.pt"),
new Customer(35,"Madalena","Sampaio","Portugal","NULL","+351 (225) 022-448","masampaio@sapo.pt"),
new Customer(36,"Hannah","Schneider","Germany","10789","+49 030 26550280","hannah.schneider@yahoo.de"),
new Customer(37,"Fynn","Zimmermann","Germany","60316","+49 069 40598889","fzimmermann@yahoo.de"),
new Customer(38,"Niklas","Schröder","Germany","10779","+49 030 2141444","nschroder@surfeu.de"),
new Customer(39,"Camille","Bernard","France","75009","+33 01 49 70 65 65","camille.bernard@yahoo.fr"),
new Customer(40,"Dominique","Lefebvre","France","75002","+33 01 47 42 71 71","dominiquelefebvre@gmail.com"),
new Customer(41,"Marc","Dubois","France","69002","+33 04 78 30 30 30","marc.dubois@hotmail.com"),
new Customer(42,"Wyatt","Girard","France","33000","+33 05 56 96 96 96","wyatt.girard@yahoo.fr"),
new Customer(43,"Isabelle","Mercier","France","21000","+33 03 80 73 66 99","isabelle_mercier@apple.fr"),
new Customer(44,"Terhi","Hämäläinen","Finland","00530","+358 09 870 2000","terhi.hamalainen@apple.fi"),
new Customer(45,"Ladislav","Kovács","Hungary","H-1073","NULL","ladislav_kovacs@apple.hu"),
new Customer(46,"Hugh","O'Reilly","Ireland","NULL","+353 01 6792424","hughoreilly@apple.ie"),
new Customer(47,"Lucas","Mancini","Italy","00192","+39 06 39733434","lucas.mancini@yahoo.it"),
new Customer(48,"Johannes","Van der Berg","Netherlands","1016","+31 020 6223130","johavanderberg@yahoo.nl"),
new Customer(49,"Stanislaw","Wójcik","Poland","00-358","+48 22 828 37 39","stanislaw.wójcik@wp.pl"),
new Customer(50,"Enrique","Muñoz","Spain","28015","+34 914 454 454","enrique_munoz@yahoo.es"),
new Customer(51,"Joakim","Johansson","Sweden","11230","+46 08-651 52 52","joakim.johansson@yahoo.se"),
new Customer(52,"Emma","Jones","United Kingdom","N1 5LH","+44 020 7707 0707","emma_jones@hotmail.com"),
new Customer(53,"Phil","Hughes","United Kingdom","SW1V 3EN","+44 020 7976 5722","phil.hughes@gmail.com"),
new Customer(54,"Steve","Murray","United Kingdom","EH4 1HH","+44 0131 315 3300","steve.murray@yahoo.uk"),
new Customer(55,"Mark","Taylor","Australia","2010","+61 (02) 9332 3633","mark.taylor@yahoo.au"),
new Customer(56,"Diego","Gutiérrez","Argentina","1106","+54 (0)11 4311 4333","diego.gutierrez@yahoo.ar"),
new Customer(57,"Luis","Rojas","Chile","NULL","+56 (0)2 635 4444","luisrojas@yahoo.cl"),
new Customer(58,"Manoj","Pareek","India","110017","+91 0124 39883988","manoj.pareek@rediff.com"),
new Customer(59,"Puja","Srivastava","India","560001","+91 080 22289999","puja_srivastava@yahoo.in")

                /*new Customer(1, "Luís", "Gonçalves", "Brazil", "12227-000", "+55 (12) 3923 - 5555", "luisg@embraer.com.br"),
                new Customer(2, "Leonie", "Köhler", "Germany", "70174", "+49 0711 2842222", "leonekohler@surfeu.de"),
                new Customer(3, "François", "Tremblay", "Canada", "H2G 1A7", "+1 (514) 721 - 4711", "ftremblay@gmail.com"),
                new Customer(4, "Bjørn", "Hansen", "Norway", "0171", "+47 22 44 22 22", "bjorn.hansen@yahoo.no"),
                new Customer(5, "František", "Wichterlová", "Czech Republic", "14700", "+420 2 4172 5555", "frantisekw@jetbrains.com"),
                new Customer(6, "Helena", "Holý", "Czech Republic", "14300", "+420 2 4177 0449", "hholy@gmail.com"),
                new Customer(7, "Astrid", "Gruber", "Austria", "1010", "+43 01 5134505", "astrid.gruber@apple.at"),
                new Customer(8, "Daan", "Peeters", "Belgium", "1000", "+32 02 219 03 03", "daan_peeters@apple.be"),
                new Customer(9, "Kara", "Nielsen", "Denmark", "1720", "+453 3331 9991", "kara.nielsen@jubii.dk"),
                new Customer(10, "Eduardo", "Martins", "Brazil", "01007-010", "+55 (11) 3033 - 5446", "eduardo@woodstock.com.br"),
                new Customer(11, "Alexandre", "Rocha", "Brazil", "01310-200", "+55 (11) 3055 - 3278", "alero@uol.com.br"),
                new Customer(12, "Roberto", "Almeida", "Brazil", "20040-020", "+55 (21) 2271 - 7000", "roberto.almeida@riotur.gov.br"),
                new Customer(13, "Fernanda", "Ramos", "Brazil", "71020-677", "+55 (61) 3363 - 5547", "fernadaramos4@uol.com.br"),
                new Customer(14, "Mark", "Philips", "Canada", "T6G 2C7", "+1 (780) 434 - 4554", "mphilips12@shaw.ca"),
                new Customer(15, "Jennifer", "Peterson", "Canada", "V6C 1G8", "+1 (604) 688 - 2255", "jenniferp@rogers.ca"),
                new Customer(16, "Frank", "Harris", "USA", "94043-1351", "+1 (650) 253 - 0000", "fharris@google.com"),
                new Customer(17, "Jack", "Smith", "USA", "98052-8300", "+1 (425) 882 - 8080", "jacksmith@microsoft.com"),
                new Customer(18, "Michelle", "Brooks", "USA", "10012-2612", "+1 (212) 221 - 3546", "michelleb @aol.com"),
                new Customer(19, "Tim", "Goyer", "USA", "95014", "+1 (408) 996 - 1010", "tgoyer @apple.com"),
                new Customer(20, "Dan", "Miller", "USA", "94040-111", "+1 (650) 644 - 3358", "dmiller @comcast.com"),
                new Customer(21, "Kathy", "Chase", "USA", "89503", "+1 (775) 223 - 7665", "kachase @hotmail.com"),
                new Customer(22, "Heather", "Leacock", "USA", "32801", "+1 (407) 999 - 7788", "hleacock @gmail.com"),
                new Customer(23, "John", "Gordon", "USA", "2113", "+1 (617) 522 - 1333", "johngordon22 @yahoo.com"),
                new Customer(24, "Frank", "Ralston", "USA", "60611", "+1 (312) 332 - 3232", "fralston @gmail.com"),
                new Customer(25, "Victor", "Stevens", "USA", "53703", "+1 (608) 257 - 0597", "vstevens @yahoo.com"),
                new Customer(26, "Richard", "Cunningham", "USA", "76110", "+1 (817) 924 - 7272", "ricunningham @hotmail.com"),
                new Customer(27, "Patrick", "Gray", "USA", "85719", "+1 (520) 622 - 4200", "patrick.gray @aol.com"),
                new Customer(28, "Julia", "Barnett", "USA", "84102", "+1 (801) 531 - 7272", "jubarnett @gmail.com"), 
                new Customer(29, "Robert", "Brown", "Canada", "M6J 1V1", "+1 (416) 363 - 8888", "robbrown @shaw.ca"),
                new Customer(30, "Edward", "Francis", "Canada", "K2P 1L7", "+1 (613) 234 - 3322", "edfrancis @yachoo.ca"),
                new Customer(31, "Martha", "Silk", "Canada", "B3S 1C5", "+1 (902) 450 - 0450", "marthasilk @gmail.com"), 
                new Customer(32, "Aaron", "Mitchell", "Canada", "R3L 2B9", "+1 (204) 452 - 6452", "aaronmitchell @yahoo.ca"), 
                new Customer(33, "Ellie", "Sullivan", "Canada", "X1A 1N6", "+1 (867) 920 - 2233", "ellie.sullivan @shaw.ca"),
                new Customer(34, "João", "Fernandes", "Portugal", "NULL", "+351 (213) 466 - 111", "jfernandes @yahoo.pt"), 
                new Customer(35, "Madalena", "Sampaio", "Portugal", "NULL", "+351 (225) 022 - 448", "masampaio @sapo.pt"),
                new Customer(36, "Hannah", "Schneider", "Germany", "10789", "+49 030 26550280", "hannah.schneider@yahoo.de"),
                new Customer(37, "Fynn", "Zimmermann", "Germany", "60316", "+49 069 40598889", "fzimmermann@yahoo.de"), 
                new Customer(38, "Niklas", "Schröder", "Germany", "10779", "+49 030 2141444", "nschroder@surfeu.de"),
                new Customer(39, "Camille", "Bernard", "France", "75009", "+33 01 49 70 65 65", "camille.bernard@yahoo.fr"), 
                new Customer(40, "Dominique", "Lefebvre", "France", "75002", "+33 01 47 42 71 71", "dominiquelefebvre@gmail.com"), 
                new Customer(41, "Marc", "Dubois", "France", "69002", "+33 04 78 30 30 30", "marc.dubois@hotmail.com"), 
                new Customer(42, "Wyatt", "Girard", "France", "33000", "+33 05 56 96 96 96", "wyatt.girard@yahoo.fr"),
                new Customer(43, "Isabelle", "Mercier", "France", "21000", "+33 03 80 73 66 99", "isabelle_mercier@apple.fr"),
                new Customer(44, "Terhi", "Hämäläinen", "Finland", "00530", "+358 09 870 2000", "terhi.hamalainen@apple.fi"), 
                new Customer(45, "Ladislav", "Kovács", "Hungary", "H-1073", "NULL", "ladislav_kovacs@apple.hu"), 
                new Customer(46, "Hugh", "O'Reilly", "Ireland", "NULL", "+353 01 6792424", "hughoreilly@apple.ie"), 
                new Customer(47, "Lucas", "Mancini", "Italy", "00192", "+39 06 39733434", "lucas.mancini@yahoo.it"),
                new Customer(48, "Johannes", "Van der Berg", "Netherlands", "1016", "+31 020 6223130", "johavanderberg@yahoo.nl"), 
                new Customer(49, "Stanisław", "Wójcik", "Poland", "00-358", "+48 22 828 37 39", "stanisław.wojcik@wp.pl"), 
                new Customer(50, "Enrique", "Muñoz", "Spain", "28015", "+34 914 454 454", "enrique_munoz@yahoo.es"), 
                new Customer(51, "Joakim", "Johansson", "Sweden", "11230", "+46 08-651 52 52", "joakim.johansson@yahoo.se"),
                new Customer(52, "Emma", "Jones", "United Kingdom", "N1 5LH", "+44 020 7707 0707", "emma_jones@hotmail.com"), 
                new Customer(53, "Phil", "Hughes", "United Kingdom", "SW1V 3EN", "+44 020 7976 5722", "phil.hughes@gmail.com"), 
                new Customer(54, "Steve", "Murray", "United Kingdom", "EH4 1HH", "+44 0131 315 3300", "steve.murray@yahoo.uk"), 
                new Customer(55, "Mark", "Taylor", "Australia", "2010", "+61 (02) 9332 3633", "mark.taylor@yahoo.au"),
                new Customer(56, "Diego", "Gutiérrez", "Argentina", "1106", "+54 (0)11 4311 4333", "diego.gutierrez@yahoo.ar"),
                new Customer(57, "Luis", "Rojas", "Chile", "NULL", "+56 (0)2 635 4444", "luisrojas@yahoo.cl"), 
                new Customer(58, "Manoj", "Pareek", "India", "110017", "+91 0124 39883988", "manoj.pareek@rediff.com"),
                new Customer(59, "Puja", "Srivastava", "India", "560001", "+91 080 22289999", "puja_srivastava@yahoo.in")*/
            };

            List<Customer> customers = new List<Customer>();
            CustomerRepository customerRep = new();

            //Act
            customers = customerRep.GetAll();

            //Assert
            Assert.Equal(expectedCustomers, customers);
        }
    }
}

