using System;
using _Neuron;
using _Neuron.Core.App;
using _Neuron.Core.NeuronNetwork;
using UnityEngine;
using Random = System.Random;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        test();
        //runGame();
    }

    private void test()
    {
        // Create a new neural network
        var neuralNetwork = new NeuralNetwork(2, 1, 2, 0.1);

        // Train the neural network
        for (int i = 0; i < 1000; i++)
        {
            // Create a random input
            var input = new double[] { new Random().NextDouble(), new Random().NextDouble() };

            // Calculate the target output
            var targetOutput = new double[] { input[0] + input[1] };

            // Train the neural network
            neuralNetwork.Train(input, targetOutput);
        }

        // Test the neural network
        var input1 = new double[] { 0.5, 0.5 };
        var output1 = neuralNetwork.Forward(input1);
        Debug.Log("Input: 0.5, 0.5 | Output: " + output1[0]);

        var input2 = new double[] { 0.2, 0.3 };
        var output2 = neuralNetwork.Forward(input2);
        Debug.Log("Input: 0.2, 0.3 | Output: " + output2[0]);
    }

    protected void runGame()
    {
        App app = new NeuronGameApp();
        App.launch(app);
    }
}
