using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    public class Table
    {
        private List<Philosofer> _philosofers;

        public Table(int countOfPhilosophers)
        {
            _philosofers = new List<Philosofer>();
            _philosofers.Add(new Philosofer()
            {
                LeftFork = new Fork(1),
                RightFork =  new Fork(2)
            });
            _philosofers[0].index = 0;
            int i;
            for (i = 1; i < countOfPhilosophers - 1; i++)
            {
                var fork = _philosofers[i - 1].RightFork;
                _philosofers.Add(new Philosofer()
                {
                    PrevPhilosopher = _philosofers[i-1],
                    LeftFork = fork,
                    RightFork = new Fork(fork.ForkNumber),
                    index = i
                });
                
                _philosofers[i - 1].NextPhilosopher = _philosofers[i];
            }
            
            _philosofers.Add(new Philosofer()
            {
                PrevPhilosopher = _philosofers[i-1],
                LeftFork =  _philosofers[countOfPhilosophers-2].RightFork,
                RightFork = _philosofers[0].LeftFork
            });

            _philosofers[i-1].NextPhilosopher = _philosofers[i];
            _philosofers[i].index = i;
            _philosofers[0].PrevPhilosopher = _philosofers[i];
            _philosofers[i].NextPhilosopher = _philosofers[0];

        }


        public void StartEating(int philospherIndex)
        {
            
            var curPhilosopher = _philosofers[philospherIndex];
                while (true)
                {
                    curPhilosopher.think();

                    curPhilosopher.takeForks();
                    curPhilosopher.eat();
                    curPhilosopher.putForks();

                    Console.WriteLine(curPhilosopher.Eated);
                }
            }
            

    }
        
    }
