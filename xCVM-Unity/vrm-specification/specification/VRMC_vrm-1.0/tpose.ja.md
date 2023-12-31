# VRM T-pose: VRM が定義する姿勢の仕様

## 概要
VRM モデルは VRM が定義する姿勢の仕様を満たす必要があります。
この文書ではその VRM が定義する姿勢の仕様を述べ、また「VRM T-pose」と呼称します。

## 定義
VRM T-pose は大きく分けて 2 つの基準による定義が存在し、すべて満たす必要があります。
第一にスキニングされたメッシュに関する見た目を基準として定義します。
第二にノードのトランスフォームに関する数値を基準として定義します。

大まかには、真っすぐに立った気を付けの姿勢から、上腕の骨だけを真横に上げて T の字になった姿勢になります。

### スキニングされたメッシュに関する見た目を基準とした定義
VRM モデルの見た目を基準に定義します。

たとえば VRM モデルに対して、靴底の面の高さ情報を計算できることは重要です。
靴底の面の高さ情報が計算できれば、VRM モデルはバーチャル空間の地面に対して適切に接地できます。
ここで一般的に、ヒューマノイドボーンのひとつ足ボーンはくるぶしの高さに存在します。
また靴の高さはメッシュの見た目によって変わるものです。
したがって足ボーンから靴底の面の高さ情報を計算することはできません。
靴底の面の高さ情報は、メッシュの見た目を基準に定義し、計算できるようにする必要があります。

定義の中で言及される軸は、指定のない限りすべて、グローバル空間の軸です。

#### 定義 1.1. 見た目上 +Z 軸方向を向いて、X 軸で左右対称に真っすぐに立っている
VRM モデルの足・胴体・頭・目の見た目は +Z 軸の方向を向いて、X 軸で左右対称に、真っすぐに立つ姿勢であると定義します。

真っすぐに立つ姿勢とは、その VRM モデルにとってリラックスしたニュートラルな姿勢です。
X: 0.0 の位置で左右対称で、視線を真正面に向けます。
また横から見て、Z: 0.0 の付近で足元から頭までなるべくまっすぐ並ぶようにします。

#### 定義 1.2. 見た目上、足は Z 軸と平行に向ける
VRM モデルの足はまっすぐ Z 軸と平行に向け、+Z 軸の方向に足先があると定義します。

たとえば足がハの字になっていたりしてはいけません。

#### 定義 1.3. 見た目上、足が接地する高さは Y: 0.0 である
靴底の面など、VRM モデルが見た目上接地する高さは Y: 0.0 と定義します。

VRM モデル制作者はモデルの見た目上の接地面を Y: 0.0 に合わせる必要があります。
たとえば hips ボーンの位置を上下に移動して調整することができます。

VRM モデル利用者はモデルの Y: 0.0 を接地面と見なすことができます。
たとえば foot ボーンからの相対位置を事前に計算し、リアルタイムに接地面を計算することができます。

#### 定義 1.4. 見た目上、腕は X 軸に沿って伸びていて、地面と平行である
見た目上、腕は X 軸に沿って伸びていて、地面と平行であると定義します。

腕を伸ばすため、真正面から見て T の字となり T-pose と呼ばれることとなります。

#### 定義 1.5. 見た目上、肩はリラックスして一番下がっている
肩ボーンが存在する場合、肩の見た目はリラックスして一番下がった状態であると定義します。

これは肩ボーンが存在しないモデルと存在するモデルで差異のない定義をするためです。
またこの定義により、腕を下げた状態で肩がどういう状態になるべきかを計算しやすくなります。

定義 1.4. と合わせると、肩は下がったまま腕は上がるという現実の人間にはできないポーズになりますが、それが定義になります。

#### 定義 1.6. 見た目上、手は X 軸に沿って伸びていて、地面と平行である
見た目上、手は X 軸に沿って伸びていて、地面と平行であると定義します。

また手のひらの面は -Y 軸の方向を向きます。

#### 定義 1.7. 見た目上、4 本の指は X 軸に沿って伸びていて、地面と平行である
見た目上、人差し指・中指・薬指・小指の 4 本の指は X 軸に沿って伸びていて、地面と平行であると定義します。

また爪の面は +Y 軸の方向を向きます。

#### 定義 1.8. 見た目上、親指は X 軸と +Z 軸の中間の方向に伸びていて、地面と平行であると定義します。
見た目上、親指は地面と平行に、X 軸と +Z 軸の中間 45 度の方向に真っすぐ伸びていると定義します。

また爪の面は他の 4 本の指とは違い 90 度外側にロールした方向を向きます。

左手の親指は +X 軸と +Z 軸の中間の方向に伸びていて、爪の面は -X 軸と +Z 軸の中間を向いています。
右手の親指は -X 軸と +Z 軸の中間の方向に伸びていて、爪の面は +X 軸と +Z 軸の中間を向いています。

### ノードのトランスフォームに関する数値を基準とした定義
スキニングされたメッシュに関する見た目を基準とした定義だけでは、ボーンの取りうる姿勢の自由度が高すぎます。
不必要に自由度が高いと、実装の複雑性が上がってしまいます。
したがってノードのトランスフォームに関する数値を基準とした定義を加えます。

#### 定義 2.1. すべてのノードのトランスフォームは、正のユニフォームスケールである
すべてのノードのトランスフォームは、正のユニフォームスケールであると定義します。
正のユニフォームスケールとは、スケールの各値が 0 ではない正の値の同じ値であると定義します。
