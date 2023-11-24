package com.kompleks;

public class Complex {

	public static final double pi = 3.14;
	double fi;
	double M;

	public Complex() {
		fi = M = 0;
	}

	public Complex(double fi, double M) throws Exception {
		if (fi < 0 || fi > pi / 4)
			throw new Exception("Fazni ugao je pogresno unesen!");
		this.fi = fi;
		this.M = M;
	}

	public String toString() {
		Double re = M * Math.cos(fi);
		Double im = M * Math.sin(fi);
		return re.toString() + (im > 0 ? " + " : " - ") + Math.abs(im) + "j";
	}

}
