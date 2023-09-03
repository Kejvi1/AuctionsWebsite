# AuctionsWebsite

The project follows the MVC design pattern and consists of these subprojects:

<ul>
  <li>
    AuctionsWebsite -> this is the main project where the views and controllers are declared.
  </li>
  <li>
    Contracts -> this is where the interfaces are declared.
  </li>
  <li>
    Entities -> this is where the models used by the project are declared.
  </li>
  <li>
    LoggerService -> this is where the logging methods are implemented. Serilog is used for logging data in a file.
  </li>
  <li>
    Repository -> this is where the methods that interact with the database are implemented. The patterns used are UOW and Repository. 
  </li>
</ul>
