using System;
using System.Linq;
using System.Collections.Generic;
using PolynomialObject.Exceptions;

namespace PolynomialObject
{
    public sealed class Polynomial
    {
        private readonly List<PolynomialMember> array;
        public List<PolynomialMember> Array
        {
            get => array;
        }
        public Polynomial()
        {

            array = new List<PolynomialMember>();
        }

        public Polynomial(PolynomialMember member)
        {

            if (member != null)
            {
                array = new List<PolynomialMember> { member };
            }
        }

        public Polynomial(IEnumerable<PolynomialMember> members)
        {

            if (members != null)
            {
                array = members.ToList();
            }
            else
            {
                array = new List<PolynomialMember>();
            }
        }

        public Polynomial((double degree, double coefficient) member)
        {

            if (Array != null)
            {
                array.Add(new PolynomialMember(member.degree, member.coefficient));
            }
            else
            {
                array = new List<PolynomialMember> { new PolynomialMember(member.degree, member.coefficient) };
            }
        }

        public Polynomial(IEnumerable<(double degree, double coefficient)> members)
        {

            if (Array == null)
            {
                array = new List<PolynomialMember>();
            }

            foreach (var mem in members)
            {
                if (mem.coefficient != 0)
                {
                    array.Add(new PolynomialMember(mem.degree, mem.coefficient));
                }
            }

        }

        /// <summary>
        /// The amount of not null polynomial members in polynomial 
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                if (Array != null)
                {
                    foreach (var poli in Array)
                    {
                        if (poli != null)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// The biggest degree of polynomial member in polynomial
        /// </summary>
        public double Degree
        {
            get
            {
                double maxNum = double.MinValue;
                if (Array != null)
                {
                    foreach (var poli in Array)
                    {
                        if (poli != null && poli.Degree > maxNum)
                        {
                            maxNum = poli.Degree;
                        }
                    }
                }
                return maxNum;
            }
        }

        /// <summary>
        /// Adds new unique member to polynomial 
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        /// <exception cref="PolynomialArgumentNullException">Throws when trying to member to add is null</exception>
        public void AddMember(PolynomialMember member)
        {

            if (member == null) throw new PolynomialArgumentNullException("Member you are trying to add is null.");
            foreach (var poli in Array)
            {
                if (Array != null && poli.Degree == member.Degree) throw new PolynomialArgumentException("Monomial with such degree already exists");
            }
            if (member.Coefficient == 0) throw new PolynomialArgumentException("Member's to add coefficient == 0");
            array.Add(member);
        }

        /// <summary>
        /// Adds new unique member to polynomial from tuple
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        public void AddMember((double degree, double coefficient) member)
        {
            foreach (var poli in array)
            {
                if (poli != null && poli.Degree == member.degree) throw new PolynomialArgumentException("Member to add with such degree already exist in polynomial");
            }
            if (member.coefficient == 0)
                throw new PolynomialArgumentException("Member's to add coefficient == 0");
            array.Add(new PolynomialMember(member.degree, member.coefficient));
        }

        /// <summary>
        /// Removes member of specified degree
        /// </summary>
        /// <param name="degree">The degree of member to be deleted</param>
        /// <returns>True if member has been deleted</returns>
        public bool RemoveMember(double degree)
        {

            if (ContainsMember(degree))
            {
                PolynomialMember item = Find(degree);
                array.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Searches the polynomial for a method of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>True if polynomial contains member</returns>
        public bool ContainsMember(double degree)
        {

            if (Array != null)
            {
                foreach (var poli in Array)
                {
                    if (poli.Degree == degree)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Finds member of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>Returns the found member or null</returns>
        public PolynomialMember Find(double degree)
        {

            if (Array != null)
            {
                foreach (var poli in Array)
                {
                    if (poli != null && poli.Degree == degree)
                    {
                        return poli;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets and sets the coefficient of member with provided degree
        /// If there is no null member for searched degree - return 0 for get and add new member for set
        /// </summary>
        /// <param name="degree">The degree of searched member</param>
        /// <returns>Coefficient of found member</returns>
        public double this[double degree]
        {
            get
            {
                PolynomialMember polynomialMember = Find(degree);
                if (polynomialMember != null) return polynomialMember.Coefficient;
                return 0;
            }
            set
            {
                if (ContainsMember(degree))
                {
                    PolynomialMember tmp = Find(degree);
                    if (tmp != null)
                    {
                        foreach (var poli in Array)
                        {
                            if (poli.Degree == tmp.Degree)
                            {
                                if (value == 0d)
                                {
                                    RemoveMember(degree);
                                    return;
                                }
                                poli.Coefficient = value;
                                return;
                            }
                        }
                    }
                }
                if (value != 0d)
                    array.Add(new PolynomialMember(degree, value));
            }
        }

        /// <summary>
        /// Convert polynomial to array of included polynomial members 
        /// </summary>
        /// <returns>Array with not null polynomial members</returns>
        public PolynomialMember[] ToArray()
        {
            List<PolynomialMember> pol = new List<PolynomialMember>();
            if (Array != null)
            {
                foreach (var poli in Array)
                {
                    if (poli != null)
                    {
                        pol.Add(poli);
                    }
                }
            }
            return pol.ToArray();
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>New polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {

            if (a == null || b == null) throw new PolynomialArgumentNullException("Either first or second polynomial is null");
            Polynomial result = new Polynomial(a.Array);
            for (int i = 0; i < b.Array.Count; i++)
            {
                if (result[b.Array[i].Degree] + b.Array[i].Coefficient == 0)
                {
                    result.RemoveMember(b.Array[i].Degree);
                }
                else
                {
                    result[b.Array[i].Degree] += b.Array[i].Coefficient;
                }
            }
            return result;

        }

        /// <summary>
        /// Subtracts two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {

            if (a == null || b == null) throw new PolynomialArgumentNullException("Either first or second polynomial is null");
            Polynomial result = new Polynomial(a.Array);
            for (int i = 0; i < b.Array.Count; i++)
            {
                if (result[b.Array[i].Degree] - Math.Abs(b.Array[i].Degree) == 0)
                {
                    result.RemoveMember(b.Array[i].Degree);
                }
                else
                {
                    result[b.Array[i].Degree] -= b.Array[i].Coefficient;
                }
            }
            if (result.Array.Any())
            {
                for (int i = 0; i < result.Array.Count; i++)
                {
                    if (result.Array[i].Coefficient == 0d)
                    {
                        result.RemoveMember(result.Array[i].Degree);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {

            if (a == null || b == null) throw new PolynomialArgumentNullException("Either first or second polynomial is null");
            Polynomial result = new Polynomial();
            foreach (var firstMem in a.Array)
            {
                foreach (var secondMem in b.Array)
                {
                    result[firstMem.Degree + secondMem.Degree] += firstMem.Coefficient * secondMem.Coefficient;
                }
            }
            return result;
        }

        /// <summary>
        /// Adds polynomial to polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Add(Polynomial polynomial)
        {

            return this + polynomial;
        }

        /// <summary>
        /// Subtracts polynomial from polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Subtraction(Polynomial polynomial)
        {

            return this - polynomial;
        }

        /// <summary>
        /// Multiplies polynomial with polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Multiply(Polynomial polynomial)
        {

            return this * polynomial;
        }

        /// <summary>
        /// Adds polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after adding</returns>
        public static Polynomial operator +(Polynomial a, (double degree, double coefficient) b)
        {
            Polynomial result;
            if ((a == null || !a.Array.Any()) && b.coefficient != 0d)
            {
                result = new Polynomial(b);
                return result;
            }
            result = new Polynomial(a.Array);
            for (int i = 0; i < result.Array.Count; i++)
            {
                if (result[b.degree] + b.coefficient == 0)
                {
                    result.RemoveMember(b.degree);
                    break;
                }
                if (result.Array[i].Degree == b.degree)
                {
                    result[b.degree] += b.coefficient;
                    break;
                }
                if (i == result.Array.Count - 1 && b.coefficient != 0)
                {
                    result.array.Add(new PolynomialMember(b.degree, b.coefficient));
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Subtract polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public static Polynomial operator -(Polynomial a, (double degree, double coefficient) b)
        {

            Polynomial result;
            if ((a == null || !a.Array.Any()) && b.coefficient != 0d)
            {
                (double deg, double coef) c = (b.degree, -b.coefficient);
                result = new Polynomial(c);
                return result;
            }
            result = new Polynomial(a.Array);
            for (int i = 0; i < a.Array.Count; i++)
            {
                if (result[b.degree] - Math.Abs(b.degree) == 0)
                {
                    result.RemoveMember(b.degree);
                    break;
                }
                if (result.Array[i].Degree == b.degree)
                {
                    result[b.degree] -= b.coefficient;
                    break;
                }
                if (i == result.Array.Count - 1 && b.coefficient != 0)
                {
                    result.array.Insert(0, new PolynomialMember(b.degree, -b.coefficient));
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Multiplies polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public static Polynomial operator *(Polynomial a, (double degree, double coefficient) b)
        {

            Polynomial result = new Polynomial();
            foreach (var firstMem in a.Array)
            {
                result[firstMem.Degree + b.degree] += firstMem.Coefficient * b.coefficient;
            }
            return result;
        }

        /// <summary>
        /// Adds tuple to polynomial
        /// </summary>
        /// <param name="member">The tuple to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        public Polynomial Add((double degree, double coefficient) member)
        {

            return this + member;
        }

        /// <summary>
        /// Subtracts tuple from polynomial
        /// </summary>
        /// <param name="member">The tuple to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public Polynomial Subtraction((double degree, double coefficient) member)
        {

            return this - member;
        }

        /// <summary>
        /// Multiplies tuple with polynomial
        /// </summary>
        /// <param name="member">The tuple for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public Polynomial Multiply((double degree, double coefficient) member)
        {

            return this * member;
        }
    }
}
