# Itinerary Planner Web Application

## Instructions

1. Run the following command to clone the repository
    ```bash
    git clone https://github.com/stefanoturcarelli/itinerary-planner-app.git
    ```

2. Navigate to the ItineraryPlanner directory: `...\itinerary-planner-app\itinerary-planner\ItineraryPlanner`

3. Open the file `ItineraryPlanner.sln`


### Could not find a part of the path ... bin\roslyn\csc.exe

Following the below steps fixed the error:

1. Delete packages folder
2. Open Solution
3. Rebuild solution
4. Observe that NuGet packages are restored, but bin\roslyn isn't created
5. Open Solution Explorer. Right-click on the project. Unload project
6. Repeat with all projects
8. Open Solution Explorer. Right-click on the project. Reload project
9. Repeat will all projects
10. Set MVC application as Startup Project
11. Rebuild solution
12. Observe that the bin\roslyn has been created now.

[Could not find a part of the path ... bin\roslyn\csc.exe](https://stackoverflow.com/questions/32780315/could-not-find-a-part-of-the-path-bin-roslyn-csc-exe#:~:text=Too%20late%20for,been%20created%20now.)
