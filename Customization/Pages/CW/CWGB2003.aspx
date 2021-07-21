<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="CWGB2003.aspx.cs" Inherits="Page_CWGB2003" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<px:PXDataSource ID="ds" runat="server" TypeName="DynamicTypesProj.DynamicTypeMaint" PrimaryView="SSDynamicView" Visible="True">
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phDialogs" runat="Server">
    <px:PXGrid ID="grid" runat="server" Height="400px" Width="100%" Style="z-index: 100"
               AllowPaging="True" AllowSearch="true" AdjustPageSize="Auto"  SyncPosition="true" NoteIndicator="true" DataSourceID="ds" SkinID="Primary" MatrixMode="True">
                <AutoSize Enabled="True" />
                <Levels>
                    <px:PXGridLevel DataMember="SSDynamicView">
                        <Columns>
                            <px:PXGridColumn DataField="Index" />
                            <px:PXGridColumn DataField="Type" />
                            <px:PXGridColumn DataField="Value" />
                        </Columns></px:PXGridLevel></Levels><AutoSize Container="Window" Enabled="True" MinHeight="200" /></px:PXGrid>
	
</asp:Content>
