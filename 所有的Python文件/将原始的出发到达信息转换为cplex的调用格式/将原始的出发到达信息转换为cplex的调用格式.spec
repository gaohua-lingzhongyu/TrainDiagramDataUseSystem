# -*- mode: python -*-

block_cipher = None


a = Analysis(['C:\\Users\\我是佟丽娅\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\将原始的出发到达信息转换为cplex的调用格式\\将原始的出发到达信息转换为cplex的调用格式.py'],
             pathex=['C:\\Users\\我是佟丽娅\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\将原始的出发到达信息转换为cplex的调用格式'],
             binaries=[],
             datas=[],
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name='将原始的出发到达信息转换为cplex的调用格式',
          debug=False,
          strip=False,
          upx=True,
          runtime_tmpdir=None,
          console=True )
