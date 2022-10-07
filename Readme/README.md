# The Letteror
 
图片设置：
1. 所有图片初始方向请朝右

输入设置：
1. 移动按键（wasd，箭头方向键，手柄左摇杆）
2. 攻击键（鼠标左键, J 键，X）
3. 跳跃键（空格，A）
4. 翻滚键（shift，B）
5. 冲刺键（大写，右肩键）
6. 特殊攻击键（I 键，Y 键）
7. 特殊冲刺键（鼠标右键，左肩键）

Parallax Controller 使用方法：
1. 将组件直接添加到需要视差效果的瓦片中即可
2. 注意代码中默认 player z 坐标为 0 
3. 注意瓦片 z 坐标 大小在 (-10,40) 间
4. 请注意本脚本没有写循环功能

Camera Confiner 用法：
1. 编辑 Camera Confiner 中的 Polygon Collider 2D 大小，即可改变摄像机移动边界

单向平台用法：
1. 添加 TileMap Collider 2D（勾选复合使用），Composite Collider 2D（勾选由效果器使用），Platform Effector 2D
将碰撞层级改为 OneWayPlatform

Dash Fruit 使用方法:
1. 将物体添加好 Rigidbody2D 和 Collider 后，将 Rigidbody2D 类型设置为 Static，将物体 Layer 改为 DashFruit