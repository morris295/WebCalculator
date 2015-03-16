using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCalculator
{
    public partial class Default : System.Web.UI.Page
    {

        private string _currentValueString = "";
        private double _currentValueDouble = 0.0;
        private string _pendingAction = "";
        private string _pendingValueString = "";
        private double _pendingValueDouble = 0.0;
        private bool _firstOperationField = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                resultTextBox.Text = "0";
            }
            else
            {
                //Respond to postback.
                _currentValueString = resultTextBox.Text;
                if (_currentValueString.Length > 0)
                {
                    _currentValueDouble = double.Parse(_currentValueString);
                }

                _firstOperationField = bool.Parse(firstOperationField.Value);
                _pendingAction = pendingActionField.Value;
                _pendingValueString = pendingValueField.Value;

                if (_pendingValueString.Length > 0)
                {
                    _pendingValueDouble = double.Parse(_pendingValueString);
                }
            }

            zeroButton.Click += new EventHandler(numberButton_Click);
            oneButton.Click += new EventHandler(numberButton_Click);
            twoButton.Click += new EventHandler(numberButton_Click);
            threeButton.Click += new EventHandler(numberButton_Click);
            fourButton.Click += new EventHandler(numberButton_Click);
            fiveButton.Click += new EventHandler(numberButton_Click);
            sixButton.Click += new EventHandler(numberButton_Click);
            sevenButton.Click += new EventHandler(numberButton_Click);
            eightButton.Click += new EventHandler(numberButton_Click);
            nineButton.Click += new EventHandler(numberButton_Click);

            divideButton.Click += new EventHandler(actionButton_Click);
            multiplyButton.Click += new EventHandler(actionButton_Click);
            subtractButton.Click += new EventHandler(actionButton_Click);
            addButton.Click += new EventHandler(actionButton_Click);
            equalButton.Click += new EventHandler(actionButton_Click);
            clearErrorButton.Click += new EventHandler(actionButton_Click);
            clearButton.Click += new EventHandler(actionButton_Click);
            backspaceButton.Click += new EventHandler(actionButton_Click);
            signButton.Click += new EventHandler(actionButton_Click);
            pointButton.Click += new EventHandler(actionButton_Click);
        }

        void numberButton_Click(object sender, EventArgs e)
        {
            int number = Int32.Parse((sender as Button).Text);

            if (_firstOperationField)
            {
                resultTextBox.Text = number.ToString();
            }
            else
            {
                if (_currentValueString == "0")
                {
                    _currentValueString = "";
                }
                resultTextBox.Text += (_currentValueString + number.ToString());
            }
        }

        void actionButton_Click(object sender, EventArgs e)
        {
            string currentAction = (sender as Button).Text;

            bool pendingOperation = (_pendingValueString.Length > 0 &&
                _currentValueString.Length > 0 && _pendingAction.Length > 0);

            if ("/*-+=".IndexOf(currentAction) >= 0)
            {
                if (pendingOperation)
                {
                    resultTextBox.Text = doCalculation(_pendingAction, _pendingValueDouble, _currentValueDouble).ToString();
                }

                firstOperationField.Value = "true";

                if (currentAction != "=")
                {
                    pendingActionField.Value = currentAction;
                    pendingValueField.Value = resultTextBox.Text;
                }
                else
                {
                    pendingActionField.Value = "";
                    pendingValueField.Value = "";
                }
            }
            else
            {
                switch (currentAction)
                {
                    case "C":
                        resultTextBox.Text = "0";
                        pendingActionField.Value = "";
                        pendingValueField.Value = "";
                        firstOperationField.Value = "true";
                        break;
                    case "CE":
                        resultTextBox.Text = "0";
                        firstOperationField.Value = "true";
                        break;
                    case "<-":
                        string newResult = _currentValueString.Substring(0, _currentValueString.Length - 1);
                        if(newResult.Length == 0 || newResult == "-")
                        {
                            resultTextBox.Text = "0";
                        }
                        else
                        {
                            resultTextBox.Text = newResult;
                        }
                        break;
                    case ".":
                        if (_currentValueString.IndexOf(".") < 0) resultTextBox.Text = _currentValueString + ".";
                        break;
                    case "+/-":
                        resultTextBox.Text = (_currentValueDouble * -1).ToString();
                        break;
                }
            }
        }

        private double doCalculation(string action, double left, double right)
        {
            double result = 0.0;
            switch (action)
            {
                case "/":
                    if(right != 0)
                    {
                        result = left / right;
                    }
                    else
                    {
                        //TODO: Handle divide by zero.
                    }
                    break;
                case "*":
                    result = left * right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "+":
                    result = left + right;
                    break;
            }

            return result;
        }
    }
}