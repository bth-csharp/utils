using Lottery;

Console.WriteLine("------------- TESTAR LOTTERYTICKET ------------");

LotteryTicket ticket = new LotteryTicket();

Console.WriteLine(ticket.GetCurrentLineNr());


if (ticket.MarkNumberOnCurrentLine(4))
    Console.WriteLine("OK");
else
    Console.WriteLine("Not ok");

if (!ticket.NextLine())
    Console.WriteLine("OK");
else
    Console.WriteLine("Not ok");

// lägg in ytterligare 6 nummer och kolla attdet därefer går att flytta till nästa rad
int[] nrs = {6, 8, 10, 11, 2, 33};
foreach (var nr in nrs)
{
    ticket.MarkNumberOnCurrentLine(nr);
    //Console.WriteLine(ticket.GetCurrentLineNr());
    string[] linesAsStrings = ticket.GetLotteryLinesAsStrings();
    Console.WriteLine(linesAsStrings[0]);
}
Console.WriteLine(ticket.NextLine());
int[] nrsLine2 = {11, 12, 13, 14, 17, 33, 2};
foreach (var nr in nrsLine2)
{
    ticket.MarkNumberOnCurrentLine(nr);
    //Console.WriteLine(ticket.GetCurrentLineNr());
}

string[] alllinesAsStrings = ticket.GetLotteryLinesAsStrings();
for (int i=0; i<=ticket.GetCurrentLineNr(); i++)
{
    Console.WriteLine(alllinesAsStrings[i]);
}
// Se till  en vinstrad
LotteryLine lottLine = new LotteryLine();