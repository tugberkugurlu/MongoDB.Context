 - Create a class by inheriting `MongoCqrsContext`. Let's call this `SampleCqrsContext`.
 - New up a `SampleCqrsContext` per each HTTP request.
 - Use `SampleCqrsContext.GetCollection<Foo>().GetByIdAsync(id)` to get the entity.
 - Do you stuff on the `Foo` entity which we have retrieved and it should be recording these operations.
 - At the end of the request, call `SampleCqrsContext.CommitAsync()` which will generate the update based on the recorded operations and do all the stuff.
 - Dispose the `SampleCqrsContext` at the end of the request.
 
## Special Cases
 
  - Q: What happens when you want to do deletes?
  - A: Don't use this then.
  
  - Q: What happens when you want to touch two entities to update per request?
  - A: No, you cannot do this with this concepts. It will fail and will do nothing.