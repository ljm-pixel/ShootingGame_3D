-- 让MainPanel继承父类BasePanel
BasePanel:subClass("MainPanel")
MainPanel.isMouse = false
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
        if(self.isMouse == false) then
            self.isMouse = true
            BagPanel:ShowMe("BagPanel")
            CS.GameUI.Instance:OpenMouse()
        else
            self.isMouse = false
            BagPanel:HideMe()
            CS.GameUI.Instance:CloseMouse()
        end
    end
end

LuaLifeFun.LuaUpdate = function()
    MainPanel:LuaUpdate()
end