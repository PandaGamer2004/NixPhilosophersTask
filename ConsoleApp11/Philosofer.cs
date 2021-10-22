using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    public enum PhilosoferState
    {
        THINKING,
        EATING,
        HUNGRY
    }
    
    public class Philosofer
    {
        public int index;
        
        private int _eated = 0;
        public object _lockObj = new Object();
        private Semaphore forkTaken = new Semaphore(0 , Int32.MaxValue);
        public Fork LeftFork
        {
            get => leftFork;
            set => leftFork = value;
        }

        public Int32 Eated => _eated;

        public Fork RightFork
        {
            get => rightFork;
            set => rightFork = value;
        }

        private Philosofer prevPhilosopher;
        private Philosofer nextPhilosopher;
        private Fork leftFork;
        private Fork rightFork;
        private PhilosoferState state;


        public Philosofer PrevPhilosopher
        {
            get => prevPhilosopher;
            set => prevPhilosopher = value;
        }

        public Philosofer NextPhilosopher
        {
            get => nextPhilosopher;
            set => nextPhilosopher = value;
        }

        public void takeForks()
        {
            lock (_lockObj)
            {
                state = PhilosoferState.HUNGRY;
                tryTakeForks();
            }
            forkTaken.Release();
            Interlocked.Increment(ref _eated);
        }

        private void tryTakeForks()
        {
            if (state == PhilosoferState.HUNGRY && prevPhilosopher.state != PhilosoferState.EATING && nextPhilosopher.state != PhilosoferState.EATING)
            {
                state = PhilosoferState.EATING;
                forkTaken.WaitOne();
            }
        }
        
        public void putForks()
        {
            lock (_lockObj)
            {
                state = PhilosoferState.THINKING;
                prevPhilosopher.tryTakeForks();
                nextPhilosopher.tryTakeForks();
            }
        }
        public async void think()
        {
            Thread.Sleep(1000);
        }

        public async void eat()
        {
            Thread.Sleep(1000);
        }
    }
    
    
    
    }