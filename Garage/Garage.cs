using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("GarageApplikation.Tests")]

namespace GarageApplikation
{
    class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
         private T[] vehicles;
        private int capacity;
        private int count;
        public int Count { get { return count; } set
            {
                value = Math.Max(0, count);
            }  }
        public bool IsFull => capacity == count;

        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            vehicles = new T[this.capacity];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }
        public void Add(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is null)
                {
                    vehicles[i] = vehicle;
                    count++; //Done? miska när du plockar ut ett fordon! 
                    break;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Remove(T vehicleToRemove)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] == vehicleToRemove)
                {
                    vehicles[i] = null;
                }
            }
        }
    }
}
/* ToDo:
 * 1: Få in user input för färg och nr of wheels samt type.
 * 2: gör en lista med alla fordon i garaget.
 * 3: iterrera över listan och kolla om färgen matchar med var enda fordon och lägg den i en ny lista.
 * 4:  itterera över den nya listan och se om nr of wheels matchar lägg den i en ny lista.
 * 5: itterera över den nya listan och se om Type matchar.
 * 6: iterrera över den sista nr och printa ut den.
*/