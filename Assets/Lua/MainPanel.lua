-- 让MainPanel继承父类BasePanel
BasePanel:subClass("MainPanel")

function MainPanel:Init(name)
    self.base.Init(self, name)
    --为了只添加一次事件监听
    if self.isInitEvent == false then
        print(self:GetControl("btnBag", "Image"))
        self:GetControl("btnBag", "Button").onClick:AddListener(function()
            self:BtnRoleClick()
        end)
        self.isInitEvent = true
    end
end
function MainPanel:BtnRoleClick()
    BagPanel:ShowMe("BagPanel")
end


function MainPanel:LuaUpdate()
    --每帧调用
    if Input.GetKeyDown(KeyCode.B) then
        print("B 按下")
        BagPanel:ShowMe("BagPanel")
    end
end

LuaLifeFun.LuaUpdate = MainPanel.LuaUpdate