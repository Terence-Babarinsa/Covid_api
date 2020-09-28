# Covid_api

#### Project Description

This project consists of a framework that allows to test the Covid-19 API, which gives information about the global situation, such as: number of cases per day, total cases per country, total deaths, and number of cases that have recovered.



#### Sprint 1

###### Goals

The goal for the first sprint was to find an API that had considerable good information to test, regarding the structure of the API response, as well as an API with good documentation which allowed for easier implementation on the framework.



###### Review

For this sprint, all collaborators have decided that the target for this project would be https://api.covid19api.com.

It has also been discussed, during this sprint, the allocation of tasks to each collaborator. Finally, the testing framework is in the initial stages of development, containing the configuration document specifying the parameters used for the API call.



###### Retrospective

During this sprint we have encountered some issues with selecting the correct API. This was due to the existence of multiple Covid-19 APIs, each one responding with different type of information. As to improve in future sprints or projects, it is important to make use of Postman to view what data it is returned from the API, as to allow for an easier decision on choosing the correct API for the project.



#### Sprint 2

###### Goals

 The goal for the second sprint was to complete the framework and reach the MVP for this project, as well as generating enough tests to confirm the legitimacy of the API and its response.



###### Review 

During this sprint, all work regarding the construction of the testing framework has been marked as done. This also include the API tests (9 tests), which included a mixture of tests using the API response as a JArray, and tests using the data model. For this sprint, the project board as also been updated with the required information being moved to the done tab.



###### Retrospective

As the majority of our errors were encountered in the first sprint, our second and last sprint was considerably less stressful as, not only we didn't encounter any major blocker but we also had a better understanding on APIs and how to build frameworks. As a result, we were able to reach our MVP.



###### Class Diagram

<img src="https://github.com/Terence-Babarinsa/Covid_api/blob/diogo/Images/Capture%20(1).png" style="zoom:80%;" />



#### Project Retrospective

The initial goal for this project was to develop an API testing framework that made calls and converted the response into our data model.  Regarding the development process, as mentioned in each individual sprint, we had a hard time coming to a decision on which API to use. This resulted in everyone trying to create sample frameworks for different APIs, as to come to a decision in which had a more detailed response. Another blocker that we encountered was the use of GitHub, as we had issues in merging our work into the master branch (still not resolved), which resulted in creating a different branch with all the work. As to improve on this, we will look more into GitHub documentation as to get more knowledge on how to solve this issue and, in addition, we plan to ask other colleagues for their opinion on how to resolve the merging issue. Lastly, this project allowed us to have a better understanding, not only on testing APIs, but also on how to collaborate and work as part of a team.



#### Project Features

To allow for multiple API calls in the framework, we implemented Polymorphism in our framework call manager:

```c#
 public string GetLatestCovidResults(string country)
        {
            var request = new RestRequest("country/" + country);
            var response = _client.Execute(request, Method.GET);
            return response.Content;
        }
        public string GetLatestCovidResults()
        {
            var request = new RestRequest("summary");
            var response = _client.Execute(request, Method.GET);
            return response.Content;
        }
```

The first method allows the user to get the results on any specific country, when instantiating the RestSharp client.

Also, as to use different API calls, we were required to overload our service constructor, as to make use of both JObject and JArray to deserialize the response from the API:

```c#
public CServices(string country)
        {
            //stores string from Api call made by CovidDataCallManager
            RecentData = CovidDataCallManager.GetLatestCovidResults(country);

            json_data = JsonConvert.DeserializeObject<JArray>(RecentData);
        }
        public CServices()
        {
            //stores string from Api call made by CovidDataCallManager
            RecentData = CovidDataCallManager.GetLatestCovidResults();

            CovidDTO.DeserialiseCovidData(RecentData);

            json_object = JsonConvert.DeserializeObject<JObject>(RecentData);
        }
```

As a result, we were then able to instantiate our service class using different parameters:

```c#
 private CServices CovidData = new CServices("united-kingdom");
 private CServices CovidPortugal = new CServices("portugal");
 private CServices CovidDataGlobal = new CServices();
```



In conclusion, with this framework we were able to create a range of NUnit tests to confirm the API response and to confirm that the information was being deserialized into our data model.

![image-20200928091028423](https://github.com/Terence-Babarinsa/Covid_api/blob/diogo/Images/tests.PNG)
