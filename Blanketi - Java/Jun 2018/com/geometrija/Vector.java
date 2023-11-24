package com.geometrija;

public abstract class Vector {
	abstract public double mod();

	abstract public Vector norm() throws Exception;

	abstract public Vector addTo(Vector v2) throws Exception;

	abstract public void print();

	abstract public int compareTo(Vector v2) throws Exception;
}
