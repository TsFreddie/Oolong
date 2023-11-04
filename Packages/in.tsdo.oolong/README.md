# Oolong

The core workflow built upon PuerTS and swc.

## What does Oolong do?

Oolong ***tries*** to provide a TypeScript workflow that closely resembles the Unity MonoBehaviour workflow.

## Is Oolong production ready?

**Probably not**, I developed this toolset for internal use at work, so we can cut down training resources when we transition from C# to TypeScript.

Initially, I plan on polishing the work and open-source it, but the incentive of polishing this work to the degree of suiting general purpose developers has diminished greatly since [the incident](https://blog.unity.com/news/plan-pricing-and-packaging-updates).

Since I've already put some work to generalize the toolset, I am open-sourcing the work as-is. As I continue to use it for work, I might update the packages from time to time.

There are no expectation for contribution, and I do strongly advise against contributing to this project if you are just starting out with Unity.

## Roadmap

This is the roadmap planned out before I stopped working on generalizing the toolset. I might still work on it if I found implementing them crucial for work.

- [x] ScriptBehaviour running and managing
- [x] In editor TypeScript transpiling
- [ ] Typescript Schema Server (for generating schema from TypeScript source)
- [ ] Schema Inspector (for editing and serializing data in Unity Editor based on schema)

