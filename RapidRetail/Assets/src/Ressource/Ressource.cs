using UnityEngine;
using System.Collections;

public class Ressource : Object {

	public string Name {get;set;}
	public int Id {get;set;}

    public override int GetHashCode()
    {
        return Id;
    }

    public override bool Equals(object o)
    {
        if (((Ressource)o).Id == this.Id) return true;
        return false;
    }

}
