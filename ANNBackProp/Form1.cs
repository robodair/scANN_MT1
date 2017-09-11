using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANNShell
{
    public partial class Form1 : Form
    {
        string dir = @"D:\SC2016\SC2016ANNv3\SC2016ANNv3\ANNBackProp\ANNBackProp\DataFiles\";

        DataClass trainData = new DataClass();
        DataClass testData = new DataClass();
        DataClass valData = new DataClass();

        public Form1()
        {
            InitializeComponent();
        }

        class UI : UserInterface
        {
            public Form1 form;

            public UI(Form1 formQ)
            {
                form = formQ;
            }

            public override void error(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "ERROR>>" + s + "\r\n";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("ERROR>>" + s, "Error", buttons);
            }
            public override void clear(string s)
            {
                form.textBox2.Text = "";
            }
            public override void warning(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "WARNING>>" + s + "\r\n";
            }
            public override void note(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "NOTE>>" + s + "\r\n";
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTest1_Click(object sender, EventArgs e)
        {
            DataClass d = new DataClass();
            d.readFromFile(dir, "test1.txt");
            string s = d.showData();
            textBox1.Text = s;
            d.writeToFile(dir, "temp.txt");
            d.normalize(0, 1, "");
            string ss = d.showData();
            textBox1.Text = textBox1.Text +"\r\n\r\n" +ss;
            DataClass d1=null;
            DataClass d2=null;
            d.extractSplit(out d1, out d2, 4, new Random());
            string s1 = d1.showData();
            string s2 = d2.showData();
            textBox1.Text = textBox1.Text + "\r\n\r\n" + s1;
            textBox1.Text = textBox1.Text + "\r\n\r\n" + s2;

        }

        private void buttonTest2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            DataClass d = new DataClass();
            d.readFromFile(dir, "test1.txt");
            string s = d.showData();
            textBox1.Text = s;
            textBox1.Text = textBox1.Text + "\r\n\r\n";

            DataClass dd = d.makeExemplar(2, 3, 1);
            string ss = dd.showData();
            textBox1.Text = textBox1.Text + ss;
            textBox1.Text = textBox1.Text + "\r\n\r\n";
        }

        private void buttonRunStudent_Click(object sender, EventArgs e)
        {
            // this is code for the student to insert/modify
        }

        private void nnProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void buttonRunWine_Click(object sender, EventArgs e)
        {
        // this is code for the run iris button
            dir = @"D:\SC2016\SC2016ANNv5\DataFiles\Iris\";
            string datafile = "IrisDataOriginalNum.txt";
            string commonNameFoDataset = "Iris";
            string prefixNameFoDataset = "Iris"; // single word
            int inputs = 4;
            int hidden = 5;
            int outputs = 3;
            double eta = 0.05;
            int epochs = 200;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 150;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            // iris button
            //nnChart.Series["Training"].Points.Clear();
            //nnChart.Series["Testing"].Points.Clear();

            textBox2.Clear(); // clear previous messages

            DataClass irisRaw = new DataClass(dir, datafile, new UI(this));
            string s = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            irisRaw.normalize(0, 3, "");
            string ss = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset+" Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass irisExemplar = irisRaw.makeExemplar(inputs, outputs, 1);
            string se = irisExemplar.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            irisExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, "tempTrain.txt"); // debug
            testData.writeToFile(dir, "tempTest.txt");
            valData.writeToFile(dir, "tempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, checkBoxGraph.Checked);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nn.showConfusion(dir + "trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nn.showConfusion(dir + "testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nn.showConfusion(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + prefixNameFoDataset+"_Weights.txt");

        }

        private void buttonFaceAssignment_Click(object sender, EventArgs e)
        {
            // Code for face assignment
            //"trainFaceBoth.txt"
            dir = @"F:\B\SC2016Assignment\FaceDataProcessed\";
            string datafile = "trainFaceBoth.txt";
            string commonNameFoDataset = "Face";
            int inputs = 49;
            int hidden = 49;
            int outputs = 2;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
        }

        private void buttonTest3_Click(object sender, EventArgs e)
        {
            // test of save and restore weights 
            Random rnd2 = new Random(40);
            int inputs = 4;
            int hidden = 5;
            int outputs = 3;

            NeuralNetwork nnn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nnn.InitializeWeights(rnd2);
            nnn.loadANN(dir + "irisWeights.txt");
   
            nnn.saveANN(dir + "irisWeights2.txt");

            double trainAcc = nnn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nnn.showConfusion(dir + "trainConfusion.txt");
            double testAcc = nnn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nnn.showConfusion(dir + "testConfusion.txt");
            double valAcc = nnn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nnn.showConfusion(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

        }

        private void buttonTimesTables_Click(object sender, EventArgs e)
        {
            // this is code for the times tables button - stull under development 

            MessageBox.Show("Option still being constructed");
            return; 

            dir = @"F:\B\SC2016Assignment\SC2016ANNv4ass\SC2016ANNv3\ANNBackProp\ANNBackProp\DataFiles\FiveTimesTables\";
            string datafile = "Tables.txt";
            string commonNameFoDataset = "Tables";
            //string commonNameFoDataset = "Tables";
            int inputs = 2;
            int hidden = 10;
            int outputs = 1;
            Random rnd1 = new Random(108); // data split random number
            Random rnd2 = new Random(114); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 50;
            int sizeOfTest = 50;
            int sizeOfValidation = 50;
            int sizeOfTrain = 50;

            
            //nnChart.Series["Training"].Points.Clear();
            //nnChart.Series["Testing"].Points.Clear();

            textBox2.Clear(); // clear previous messages

            DataClass tablesRaw = new DataClass(dir, datafile, new UI(this));

            tablesRaw.normalize(0, 2, dir+ "NormaliseParams.txt"); // normalise all
            string ss = tablesRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass(tablesRaw);
            testData = new DataClass(tablesRaw);
            valData = new DataClass(tablesRaw);

            trainData.writeToFile(dir, "train.txt");
            testData.writeToFile(dir, "test.txt");
            valData.writeToFile(dir, "val.txt");


            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.functionAproximator = true;
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, 200, 0.05, dir + "nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            // process outputs
            nn.processDataset(trainData.data, dir + "trainOut.txt");
            nn.processDataset(testData.data, dir + "testOut.txt");
            nn.processDataset(valData.data, dir + "valOut.txt");


            // finally save weights for the future
            nn.saveANN(dir + "TablesWeights.txt");

        }

        private void buttonHeartCleveland_Click(object sender, EventArgs e)
        {
            // this is code for the run Abalone button
            dir = @"D:\SC2016\SC2016ANNv5\DataFiles\Abalone\";
            string datafile = "Abalone.txt";
            string commonNameFoDataset = "Abalone";
            string prefixNameFoDataset = "Abalone";
            int inputs = 8;
            int hidden = 8;
            int outputs = 3;
            double eta = 0.05;
            int epochs = 1000;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 4177;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            // iris button
            //nnChart.Series["Training"].Points.Clear();
            //nnChart.Series["Testing"].Points.Clear();

            textBox2.Clear(); // clear previous messages

            DataClass irisRaw = new DataClass(dir, datafile, new UI(this));
            string s = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            // its fairly good no real need to normalise
            //irisRaw.normalize(0, 1, "");
            //string ss = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset + " Normalised");
            //textBox1.AppendText(ss);
            //textBox1.AppendText("\r\n\r\n");

            DataClass irisExemplar = irisRaw.makeExemplar(inputs, outputs, 1);
            string se = irisExemplar.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            irisExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, "tempTrain.txt"); // debug
            testData.writeToFile(dir, "tempTest.txt");
            valData.writeToFile(dir, "tempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, checkBoxGraph.Checked);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nn.showConfusion(dir + "trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nn.showConfusion(dir + "testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nn.showConfusion(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + prefixNameFoDataset+"_Weights.txt");

        }

        private void buttonRun4000_Click(object sender, EventArgs e)
        {
            // Run 4000e10 Constructed data set
            dir = @"D:\SC2016\SC2016ANNv5\DataFiles\Known4000e10\";
            string datafile = "Data4000e10.txt";
            string commonNameFoDataset = "Data4000e10";
            string prefixNameFoDataset = "Data4000e10"; // single word
            int inputs = 2;
            int hidden = 8;
            int outputs = 2;
            double eta = 0.05;
            int epochs = 200;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 4000;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass irisRaw = new DataClass(dir, datafile, new UI(this));
            string s = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            //irisRaw.normalize(0, 1, "");
            //string ss = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset + " Normalised");
            //textBox1.AppendText(ss);
            //textBox1.AppendText("\r\n\r\n");

            DataClass irisExemplar = irisRaw.makeExemplar(inputs, outputs, 1);
            string se = irisExemplar.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            irisExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, "tempTrain.txt"); // debug
            testData.writeToFile(dir, "tempTest.txt");
            valData.writeToFile(dir, "tempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameFoDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + "trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + "testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + prefixNameFoDataset + "_Weights.txt");

        }

        private void buttonRunCancer_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\cancer.txt";
            string commonNameForDataset = "Cancer Dataset";

            int inputs = 9;
            int hidden = 1;
            int outputs = 2;
            double eta = 0.05;
            int epochs = 200;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 683;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass cancerRaw = new DataClass(dir, datafile, new UI(this));
            string s = cancerRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            //irisRaw.normalize(0, 1, "");
            //string ss = irisRaw.showDataPart(5, inputs + 1, "F4", commonNameFoDataset + " Normalised");
            //textBox1.AppendText(ss);
            //textBox1.AppendText("\r\n\r\n");

            DataClass cancerExemplar = cancerRaw.makeExemplar(inputs, outputs, 1);
            string se = cancerExemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            cancerExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\cancerTempTrain.txt"); // debug
            testData.writeToFile(dir, @"\cancerTempTest.txt");
            valData.writeToFile(dir, @"\cancerTempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + "trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + "testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\cancer_Weights.txt");
        }
    }
}
