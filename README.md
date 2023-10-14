# entity-framework-postgres
Testing entity framework with postgres running locally in docker

## Unit of Work

The Unit of Work pattern is being used here to ensure that we get transactional integrity across our repositories. The unit of work pattern allows us to decouple our application from dbContext's as it is not coupled to entity framework. We specify access to our repositories in here and provide an implementation of things like saving state across the repos here. We also make this IDisposable so that when it's disposed of, we clean it up.

https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
