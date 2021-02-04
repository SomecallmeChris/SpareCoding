#include <iostream>
#include <vector>
#include <numeric>
/*
1) Create a sample of random values that are randomised per 10 values.
   DONE

2) Create a rolling filter for a set of data 200 in size.
   To do this average 5 values at a time and store the averaged value in a new array

3) From the new averaged values, find the trailing and leading index's
   (When a value is first over 50 for leading, and lower than 50 for trailing)

4) Exclude the values 20 in from both the leading and trailing index's.

5) Find the minimum value within our set of data

6) Find all values that are atleast 30 above our minimum value
*/
struct results{
    int leadingValueIndex = 0;
    int trailingValueIndex = 0;
    int minValue = 500;
    std::vector<int> dataSet;
};

int main()
{
    int sample[] = {0,   0,  0,  0,  0,  6,  91, 98, 82, 94, 93, 99, 90, 98,  98, 88,  87, 95, 85, 99, // 20
                    96, 88, 98, 93, 94, 95, 106, 88, 89, 88, 85, 91, 94, 96, 108, 85, 102, 91, 96, 96, // 40
                    91, 90, 98, 90, 94, 97,  96, 85, 86, 92, 91, 80, 88, 89,  99, 94,  96, 98, 90, 82, // 60
                    89, 89, 80, 81, 85, 80,  86, 91, 88, 83, 87, 83, 73, 91,  84, 85,  87, 86, 84, 87, // 80
                    114, 135, 109, 104, 119, 133, 101, 132, 124, 127, 119, 124, 103, 129, 122, 118, 134, 122, 122, 127, // 100
                    97, 110, 110, 90, 96, 94, 106, 103, 91, 99, 99, 96, 101, 91, 92, 104, 103, 108, 106, 104, // 120
                    98, 87, 89, 91, 96, 86, 88, 93, 87, 99, 90, 91, 86, 88, 95, 81, 90, 97, 83, 92, // 140
                    89, 86, 84, 88, 89, 87, 85, 80, 88, 83, 80, 88, 88, 89,  0,  0,  0,  0,  4,  0 // 160
                    };

    std::vector<int> averageResults;
    int sampleSize = (sizeof(sample)/sizeof(*sample));
    std::vector<int> tempStore;
    results results;
    int tempMinvalue = 0;

    // 5-tap averaging filter
    for(int i = 0; i < sampleSize; i++)
    {
       if(tempStore.size() == 5)
       {
           averageResults.push_back(std::accumulate(tempStore.begin(), tempStore.end(), 0)/5);
           tempStore.push_back(sample[i]);
           tempStore.erase(tempStore.begin());
       }
       else
       {
           averageResults.push_back(sample[i]);
           tempStore.push_back(sample[i]);           
       }
    }

    // Mark leading and trailing values
    for(int i = 0; i < averageResults.size(); i++)
    {
        if(averageResults[i] >= 50 && results.leadingValueIndex == 0)
        {
            results.leadingValueIndex = i;
        }
        else if(averageResults[i] <= 50 && results.leadingValueIndex > 0)
        {
            results.trailingValueIndex = i;
            break;
        }
    }

    for(int i = 0; i < averageResults.size(); i++)
    {
        std::cout << averageResults[i] << ", ";
        if(i % 20 == 0 && i != 0)
        {
            std::cout << "\n";
        }
    }
    std::cout << "\n";
    std::cout << "\n";

    // Clip values we don't care about
    averageResults.erase(averageResults.end()-(averageResults.size()-results.trailingValueIndex), averageResults.end());
    averageResults.erase(averageResults.begin(), averageResults.begin()+results.leadingValueIndex);
    // Exclude data from leading and trailing index's
    averageResults.erase(averageResults.end()-20, averageResults.end());
    averageResults.erase(averageResults.begin(), averageResults.begin()+20);

    // Find minimum value in our dataset
    for(int i = 0; i < averageResults.size(); i++)
    {
        if(averageResults[i] < results.minValue)
        {
            results.minValue = averageResults[i];
        }
    }

    // Print averaged data
    for(int i = 0; i < averageResults.size(); i++)
    {
        std::cout << averageResults[i] << ", ";
        if(i % 20 == 0 && i != 0)
        {
            std::cout << "\n";
        }
    }
    std::cout << "\nResults min.value = " << results.minValue << std::endl;
    std::cout << "Results leading.value = " << results.leadingValueIndex << std::endl;
    std::cout << "Results trailing.value = " << results.trailingValueIndex << std::endl;
}