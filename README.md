# Neo4j Graph Search Engine

gSearch is a graph search engine architecture that integrates with a Neo4j graph database. The core libraries of gSearch contain a collection of graph management services for recording and analyzing complex dynamical systems of temporally modeled interactions.

![gSearch](https://raw.github.com/kbastani/gsearch/master/Images/gsearch-logo-thumb-200x200.PNG)

## What problems does gSearch solve?

gSearch is meant to solve specific problems in the field of information retrieval and search.

### Filter

TODO

### Search

TODO

### Recommendation

TODO

### Causality

gSearch allows you to painlessly perform causal analysis of temporally modeled events.

#### Definition

[Causality](http://en.wikipedia.org/wiki/Causality) (also referred to as causation) is the relation between an event (the cause) and a second event (the effect), where the second event is understood as a consequence of the first.

#### Theory

 ***
 
Observations are made, captured, from a perspective of a position in time and space. A graph is a model of that space.

A graph database provides you a means to model space and see information from the perspective of a point relative to other points. Those points can represent a condition or state of the world.

#### Example

Consider the example below.

* Pam met Sally.
* John met Sally.
* Sally met Anne.
* Anne met Pam.

Each point on the graph is from the perspective of a person relative to meeting other people.

![Event_Model](https://raw.github.com/kbastani/gists/master/meta/event-model-1.png)

#### Problem

The need to model these abstract representations of interactions between objects in a temporal sense, ordered chronologically, requires database management solutions that are complex and contextually diverse.

![Event_Interaction_Model](https://raw.github.com/kbastani/gists/master/meta/TSEMM-Temporal-Binding.png)

#### Solution

gSearch exposes an API for handling data management operations purposed to performantly manage read and write operations for creating and maintaining a causal graph in your Neo4j graph database.


