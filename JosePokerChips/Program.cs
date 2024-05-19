namespace JosePokerChips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите через запятую количество фишек: ");
                string[] strs = Console.ReadLine()!.Split(',');

                int elementsCount = strs.Length;
                int[] chips = new int[elementsCount];

                int sumChips = 0, numMoves = 0, iMin = 0, iMax = 0;

                for (int i = 0; i < elementsCount; i++)
                {
                    chips[i] = int.Parse(strs[i]);
                    sumChips += chips[i];

                    if (chips[iMax] < chips[i]) iMax = i;
                    if (chips[iMin] > chips[i]) iMin = i;
                }

                if (sumChips % elementsCount != 0)
                {
                    Console.WriteLine("Фишки не делятся поровну между игроками");
                    break;
                }

                while (iMax > iMin)
                {
                    if (iMin < iMax)
                    {
                        if (iMax - iMin > elementsCount / 2)
                        {
                            chips[iMax]--;
                            if (iMax < elementsCount - 1)
                                iMax++;
                            else iMax = 0;
                            chips[iMax]++;
                        }
                        else
                        {
                            chips[iMax]--;
                            if (iMax > 0)
                                iMax--;
                            else iMax = elementsCount - 1;
                            chips[iMax]++;
                        }
                    }
                    else
                    {
                        if (iMin - iMax < elementsCount / 2)
                        {
                            chips[iMax]--;
                            if (iMax < elementsCount - 1)
                                iMax++;
                            else iMax = 0;
                            chips[iMax]++;
                        }
                        else
                        {
                            chips[iMax]--;
                            if (iMax > 0)
                                iMax--;
                            else iMax = elementsCount - 1;
                            chips[iMax]++;
                        }
                    }
                    numMoves++;
                    iMin = 0; iMax = 0;

                    for (int i = 0; i < elementsCount; i++)
                    {
                        if (chips[iMax] < chips[i])
                            iMax = i;
                        if (chips[iMin] > chips[i])
                            iMin = i;
                    }
                }

                Console.WriteLine(numMoves);
            }
        }
    }
}
