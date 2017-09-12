using System.Collections;
using System.Collections.Generic;

public class RoomsRegister : IEnumerable<int>
{
    private readonly List<Pet> rooms;
    private readonly int centralRoomIndex;

    public RoomsRegister(int roomsNumber)
    {
        this.centralRoomIndex = roomsNumber / 2;
        this.rooms = new List<Pet>(new Pet[roomsNumber]);
    }

    public Pet this[int index]
    {
        get { return this.rooms[index]; }

        set { this.rooms[index] = value; }
    }

    public IEnumerator<int> GetEnumerator()
    {
        int step = 1;
        yield return this.centralRoomIndex;

        while (step <= this.centralRoomIndex)
        {
            yield return this.centralRoomIndex - step;
            yield return this.centralRoomIndex + step;
            step++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}