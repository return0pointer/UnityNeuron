using System;

namespace _Neuron.Core.NeuronNetwork
{
    public class NeuralNetwork
{
    public int InputSize { get; set; }
    public int OutputSize { get; set; }
    public int HiddenSize { get; set; }
    public double LearningRate { get; set; }
    public double[,] WeightsInputToHidden { get; set; }
    public double[,] WeightsHiddenToOutput { get; set; }

    public NeuralNetwork(int inputSize, int outputSize, int hiddenSize, double learningRate)
    {
        InputSize = inputSize;
        OutputSize = outputSize;
        HiddenSize = hiddenSize;
        LearningRate = learningRate;
        WeightsInputToHidden = new double[InputSize, HiddenSize];
        WeightsHiddenToOutput = new double[HiddenSize, OutputSize];
        InitializeWeights();
    }

    public void InitializeWeights()
    {
        var rnd = new Random();
        for (int i = 0; i < InputSize; i++)
        {
            for (int j = 0; j < HiddenSize; j++)
            {
                WeightsInputToHidden[i, j] = rnd.NextDouble();
            }
        }

        for (int i = 0; i < HiddenSize; i++)
        {
            for (int j = 0; j < OutputSize; j++)
            {
                WeightsHiddenToOutput[i, j] = rnd.NextDouble();
            }
        }
    }

    public double[] Forward(double[] input)
    {
        // Calculate the input to hidden layer
        var inputToHidden = new double[HiddenSize];
        for (int i = 0; i < HiddenSize; i++)
        {
            for (int j = 0; j < InputSize; j++)
            {
                inputToHidden[i] += input[j] * WeightsInputToHidden[j, i];
            }
        }

        // Calculate the hidden to output layer
        var hiddenToOutput = new double[OutputSize];
        for (int i = 0; i < OutputSize; i++)
        {
            for (int j = 0; j < HiddenSize; j++)
            {
                hiddenToOutput[i] += inputToHidden[j] * WeightsHiddenToOutput[j, i];
            }
        }

        return hiddenToOutput;
    }

    public void Train(double[] input, double[] targetOutput)
    {
        // Calculate the input to hidden layer
        var inputToHidden = new double[HiddenSize];
        for (int i = 0; i < HiddenSize; i++)
        {
            for (int j = 0; j < InputSize; j++)
            {
                inputToHidden[i] += input[j] * WeightsInputToHidden[j, i];
            }
        }

        // Calculate the hidden to output layer
        var hiddenToOutput = new double[OutputSize];
        for (int i = 0; i < OutputSize; i++)
        {
            for (int j = 0; j < HiddenSize; j++)
            {
                hiddenToOutput[i] += inputToHidden[j] * WeightsHiddenToOutput[j, i];
            }
        }

        // Calculate the output error
        var outputError = new double[OutputSize];
        for (int i = 0; i < OutputSize; i++)
        {
            outputError[i] = targetOutput[i] - hiddenToOutput[i];
        }

        // Calculate the hidden error
        var hiddenError = new double[HiddenSize];
        for (int i = 0; i < HiddenSize; i++)
        {
            for (int j = 0; j < OutputSize; j++)
            {
                hiddenError[i] += outputError[j] * WeightsHiddenToOutput[i, j];
            }
        }

        // Update the weights
        for (int i = 0; i < InputSize; i++)
        {
            for (int j = 0; j < HiddenSize; j++)
            {
                WeightsInputToHidden[i, j] += LearningRate * input[i] * hiddenError[j];
            }
        }

        for (int i = 0; i < HiddenSize; i++)
        {
            for (int j = 0; j < OutputSize; j++)
            {
                WeightsHiddenToOutput[i, j] += LearningRate * inputToHidden[i] * outputError[j];
            }
        }
    }
}
}