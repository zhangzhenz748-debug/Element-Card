# Element Card - 异步卡牌战斗框架原型

基于 Unity 开发的 Roguelike 卡牌战斗系统，核心侧重于**高内聚低耦合**的架构设计与**高性能渲染**优化。

## 💎 技术亮点

### 1. 异步战斗流水线 (Async Combat Pipeline)
* **核心组件**：`CombatManager`
* **实现方案**：利用 `Queue<ICommand>` 与协程（Coroutine）驱动，将卡牌效果、数值结算、动画表现（前摇/后摇）完全解耦，解决复杂连击下的时序冲突。

### 2. 双层事件总线 (Event Bus)
* **全局层**：处理 UI 刷新与转场。
* **局部层**：`MonsterEvent` 处理怪物死亡、受击等局部逻辑。
* **优势**：UI 脚本与核心逻辑 0 引用，极大降低了项目后期维护成本。

### 3. 性能优化 (Performance Optimization)
* **对象池技术**：全量接入 `UnityEngine.Pool`，对频繁生成的“战斗手牌”与“粒子特效”进行复用，实测战斗过程中 **0 GC 抖动**。
* **资源加载**：预留了 Addressables 接口，方便后续扩展大数据量资源。

## 🛠️ 快速预览
* **开发环境**：Unity 2021.3+ / C#
* **核心逻辑目录**：`Assets/Scripts/Core/Combat/`
