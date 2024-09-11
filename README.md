
# Clone my repository

Open your terminal and run the following command to clone the repository.

    git clone https://github.com/alvinyanson/RedisAsDbAPI.git


## Deploy and Run Redis in a Docker Container

Ensure that Docker is installed on your system before executing the command below.

    docker run -d --name my-redis-stack -p 6379:6379  redis/redis-stack-server:latest


## Verify that the redis container is running

In your terminal, run the command below:

    docker ps

When you see a message like this, it indicates that Redis is successfully running in Docker.

    CONTAINER ID   IMAGE                                        COMMAND          STATUS           PORTS                     NAMES
    885568fdf77e     redis/redis-stack-server:latest   "/entrypoint.sh"    Up 3 minutes   0.0.0.0:6379->6379/tcp   my-redis-stack


## Run Redis Insight docker image

To view the Redis database in a GUI, we will use Redis Insight.

    docker run -d --name redisinsight -p 5540:5540 redis/redisinsight:latest


## Add database

Open your browser and navigate to [http://localhost:5540](http://localhost:5540).

Click on **Add Database**.

In the **host** field, enter `host.docker.internal`.

Leave the **port** field set to the default value of `6379`.




## Run the application

Open Postman and access the provided endpoints.

- Get All Platforms - https://localhost:7236/api/platforms
- Get Platform By Id - https://localhost:7236/api/platforms/{id}
- Add New Pecord - https://localhost:7236/api/platforms ( Sample payload - {"name": "Redis"} )

## Redis Insight
![RedisInsight](https://raw.githubusercontent.com/alvinyanson/RedisAsDbAPI/master/Screenshot%202024-09-11%20123356.png)

