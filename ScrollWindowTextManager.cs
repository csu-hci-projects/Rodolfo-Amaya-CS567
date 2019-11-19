using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWindowTextManager : MonoBehaviour
{
    public SelectionManager _selectionManager;

    [SerializeField]
    public RectTransform text;

    public static string BoolInformation = "The Boolean data type is a data type that has one of two possible values (usually denoted true and false) which is intended to represent the two truth values of logic and Boolean algebra. It is named after George Boole, who first defined an algebraic system of logic in the mid 19th century. The Boolean data type is primarily associated with conditional statements, which allow different actions by changing control flow depending on whether a programmer-specified Boolean condition evaluates to true or false. Bits: 1";

    public static string Unsigned16Information = "Integral types may be unsigned (capable of representing only non-negative integers) or signed (capable of representing negative integers as well). This unsigned type can represent values from 0 to 65,535, which equals 216 − 1. Another word for this type is 'short'. Bits: 16";

    public static string Unsigned32Information = "This unsigned type can represent values from 0 to 4,294,967,295, which equals 232 − 1. Another word for this type is 'long' or simply 'int'. Bits: 32";

    public static string FloatInformation = "In computing, floating-point arithmetic (FP) is arithmetic using formulaic representation of real numbers as an approximation to support a trade-off between range and precision. The term floating point refers to the fact that a number's radix point (decimal point, or, more commonly in computers, binary point) can 'float'; that is, it can be placed anywhere relative to the significant digits of the number. Bits: 32";

    public static string DoubleInformation = "An integral type. The unsigned version can represent values from 0 to 18,446,744,073,709,551,615, which equals 264 − 1. Bits: 64";

    public static string StructInformation = "In object-oriented programming (OOP), encapsulation refers to the bundling of data with the methods that operate on that data, or the restricting of direct access to some of an object's components. Encapsulation is used to hide the values or state of a structured data object inside a class, preventing unauthorized parties' direct access to them. In C programming languages this encapsulation can be done in either a class or a struct.";

    public static string MainInformation = "In computer programming, an entry point is where the first instructions of a program are executed, and where the program has access to command line arguments. To start a program's execution, the loader or operating system passes control to its entry point. Alternatively, execution of a program can begin at a named point, either with a conventional name defined by the programming language or operating system or at a caller-specified name. In many C-family languages, this is a function named 'main'; as a result, the entry point is often known as the main function.";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform _s = _selectionManager.GetCurrentLongTouch();
        //Show text for the latest selection
        if (_s != null)
        {
            string _name = _s.name.Replace("(Clone)", "");
            //print(_name);
            switch (_name)
            {
                case ("Bool"):
                    text.GetComponent<UnityEngine.UI.Text>().text = BoolInformation;
                    break;
                case ("Uint16"):
                    text.GetComponent<UnityEngine.UI.Text>().text = Unsigned16Information;
                    break;
                case ("Uint32"):
                    text.GetComponent<UnityEngine.UI.Text>().text = Unsigned32Information;
                    break;
                case ("Float"):
                    text.GetComponent<UnityEngine.UI.Text>().text = FloatInformation;
                    break;
                case ("Double"):
                    text.GetComponent<UnityEngine.UI.Text>().text = DoubleInformation;
                    break;
                case ("Struct"):
                    text.GetComponent<UnityEngine.UI.Text>().text = StructInformation;
                    break;
                case ("Main"):
                    text.GetComponent<UnityEngine.UI.Text>().text = MainInformation;
                    break;
                default:
                    break;
            }
        }
        else 
        {
            //print("INSANE SLEEPER CARS");
        }
    }
}
